# BindableObject

Xamarin.Forms のコントロールは全て BindableObject を継承関係の祖先として持っています。この BindableObject クラスはデータ バインディングの機能やバインダブルプロパティや添付プロパティなどといった重要な機能を提供しています。

## バインダブルプロパティ

バインダブルプロパティは以下の特徴を持つ特別なプロパティです。

- データバインディングのターゲットとして使用可能
- スタイルが設定可能
- デフォルト値を設定可能
- 値のバリデーションが可能
- 値の変更を監視可能

バインダブルプロパティを定義するには BindableObject を継承して、 BindableProperty.Create メソッドを呼び出します。
結果は static readonly なフィールドとして保持します。Name というバインダブルプロパティを持った Person クラスの定義を以下に示します。

```cs
using Xamarin.Forms;

namespace HelloWorld
{
    public class Person : BindableObject
    {
        public static readonly BindableProperty NameProperty = BindableProperty.Create(
            "Name",
            typeof(string),
            typeof(Person));

        public string Name
        {
            get { return (string)this.GetValue(NameProperty); }
            set { this.SetValue(NameProperty, value); }
        }
    }
}
```

BindableProperty.Create にプロパティ名、プロパティの型、プロパティを所持するクラスの型を指定します。戻ってくる BindableProperty のインスタンスを static readonly のフィールドで保持します。この時のフィールド名は「プロパティ名 Property」にします。これでバインダブルプロパティは定義できました。次に C# から簡単にアクセスできるように CLR プロパティのラッパーを作ります。get アクセサーで GetValue メソッドをつかって BindableProperty をキーにして値を取得します。set アクセサーで SetValue メソッドを使って BindableProperty をキーにして値を設定します。これが最低限なバインダブルプロパティの作成方法です。

バインダブルプロパティにはデフォルト値が指定可能です。BindableProperty.Create メソッドのプロパティを所持するクラスの型に続いてデフォルト値を設定するだけです。tanaka をデフォルト値としたい場合のバインダブルプロパティの定義は以下のようになります。

```cs
public static readonly BindableProperty NameProperty = BindableProperty.Create(
    "Name",
    typeof(string),
    typeof(Person),
    "tanaka");
```

プロパティの変更時の処理を記述することもできます。BindableProperty.Create メソッドの propertyChanged 引数を指定することでコールバックを指定できます。コールバックの引数は、第一引数に変更があったクラスのインスタンス、第二引数に古い値、第三引数に新しい値になります。コード例を以下に示します。

```cs
public static readonly BindableProperty NameProperty = BindableProperty.Create(
    "Name",
    typeof(string),
    typeof(Person),
    "tanaka",
    propertyChanged: OnNameChanged);

private static void OnNameChanged(BindableObject bindable, object oldValue, object newValue)
{
    // 変更前と変更後の値を使って何かする
}
```

valudateValue 引数を指定することで、値の検証ロジックを追加できます。第一引数にオブジェクトの参照、第二引数に値が渡ってきます。戻り値として、検証結果を bool 型で返します。

```cs
public static readonly BindableProperty NameProperty = BindableProperty.Create(
    "Name",
    typeof(string),
    typeof(Person),
    "tanaka",
    validateValue: OnNameValidateValue);

private static bool OnNameValidateValue(BindableObject bindable, object value)
{
    // バリデーションロジックを書きます
    var name = (string)value;
    return !string.IsNullOrEmpty(name);
}
```

coerceValue 引数を指定することで、プロパティに設定された値を矯正することができます。用途としては、最大値、最小値のプロパティがあるようなクラスで、値が最小値と最大値の間に来るように調整するといったものがあります。コールバックの引数は、第一引数にオブジェクトの参照、第二引数に値が渡ってきます。戻り値として、矯正後の値を返します。例として、10 文字より長い名前は 10 文字に切り詰める場合のコードを以下に示します。

```cs
public static readonly BindableProperty NameProperty = BindableProperty.Create(
    "Name",
    typeof(string),
    typeof(Person),
    "tanaka",
    coerceValue: OnNameCoerceValue);

private static object OnNameCoerceValue(BindableObject bindable, object value)
{
    // 値の調整ロジックを書く
    var name = (string)value;
    if (name.Length > 10)
    {
        name = name.Substring(0, 10);
    }
    return name;
}
```

バインダブルプロパティは、読み取り専用として定義することもできます。読み取り専用にするには、BindableProperty.CreateReadOnly メソッドを使って BindablePropertyKey を取得します。この BindablePropertyKey を private で管理します。値の書き込みは、この BindablePropertyKey を通して行います。値の取得は BindablePropertyKey クラスの BindableProperty プロパティで取得できる BindableProperty クラスを使用して行います。一般的な読み取り専用のバインダブルプロパティの定義を以下に示します。

```cs
// 読み取り専用のBindablePropertyKeyを定義(privateに管理する)
private static readonly BindablePropertyKey AgePropertyKey = BindableProperty.CreateReadOnly(
    "Age",
    typeof(int),
    typeof(Person),
    0);
// KeyからBindablePropertyを取得
public static readonly BindableProperty AgeProperty = AgePropertyKey.BindableProperty;

public int Age
{
    // 読み取りは通常通りBindablePropertyで行う。
    get { return (int)this.GetValue(AgeProperty); }
    // 書き込みはBindablePropertyKeyで行う
    private set { this.SetValue(AgePropertyKey, value); }
}
```

## 添付プロパティ

ここでは、他の BindableObject に対して別のオブジェクトで定義されたプロパティの値を設定、取得することができる添付プロパティについて説明します。添付プロパティは XAML で解説したようにレイアウトのコントロールでよく使われています。BindableObject の添付プロパティの仕組みと深く結びついています。
添付プロパティの定義は BindableProperty.CreateAttached を使う点を除くとバインダブルプロパティとほぼ同じです。添付プロパティは、インスタンスに紐づかないため CLR のプロパティラッパーは作成しません。その代わりに「戻り値 Getプロパティ名(BindableObject)」「void Setプロパティ名(BindableObject, プロパティの型)」といったシグネチャの static なメソッドでラップします。Row 添付プロパティの定義例を以下に示します。

```cs
public static readonly BindableProperty RowProperty = BindableProperty.CreateAttached(
    "Row",
    typeof(int),
    typeof(MyGrid),
    0);

public static int GetRow(BindableObject obj)
{
    return (int)obj.GetValue(RowProperty);
}

public static void SetRow(BindableObject obj, int value)
{
    obj.SetValue(RowProperty, value);
}
```

