# レイアウトコントロール

ここでは Xamarin.Forms でレイアウトに関係するコントロールについて紹介します。Xamarin.Forms では、以下のように様々なレイアウトコントロールが提供されています。

- StackLayout
- Grid
- AbsoluteLayout
- RelativeLayout
- ScrollView

## StackLayout

StackLayout は名前の通りスタック状にコントロールを並べて配置するコントロールです。デフォルトでは縦にコントロールを並べますが Orientation プロパティに Horizontal を指定することで横並びに配置することもできます。StackLayout の基本的な使い方の例を以下に示します。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:HelloWorld"
             xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core"
             ios:Page.UseSafeArea="true"
             x:Class="HelloWorld.MyPage">
    <StackLayout>
        <BoxView Color="Red" />
        <BoxView Color="Blue" />
        <BoxView Color="Yellow" />
    </StackLayout>
</ContentPage>
```

実行すると、縦に赤、青、黄色の矩形が並んで表示されます。実行結果を以下に示します。

![Android StackLayout](images/android-stacklayout.png)

![iOS StackLayout](images/ios-stacklayout.png)

Orientation プロパティを Horizontal(デフォルトは Vertical)に設定することで横並びにすることができます。XAML を以下に示します。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:HelloWorld"
             xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core"
             ios:Page.UseSafeArea="true"
             x:Class="HelloWorld.MyPage">
    <StackLayout Orientation="Horizontal">
        <BoxView Color="Red" />
        <BoxView Color="Blue" />
        <BoxView Color="Yellow" />
    </StackLayout>
</ContentPage>
```

実行結果を以下に示します。

![Android StackLayout Horizontal](images/android-stacklayout-horizontal.png)

![iOS StackLayout Horizontal](images/ios-stacklayout-horizontal.png)

Spacing プロパティに数字を指定すると指定したサイズだけ要素間に空白ができます。XAML の例を以下に示します。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:HelloWorld"
             xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core"
             ios:Page.UseSafeArea="true"
             x:Class="HelloWorld.MyPage">
    <StackLayout Spacing="25">
        <BoxView Color="Red" />
        <BoxView Color="Blue" />
        <BoxView Color="Yellow" />
    </StackLayout>
</ContentPage>
```

実行すると以下のようになります。

![Android StackLayout Spacing](images/android-stacklayout-spacing.png)

![iOS StackLayout Spacing](images/ios-stacklayout-spacing.png)

余白があいていることが確認できます。

さらにコントロールの HorizontalOptions プロパティ、VerticalOptions プロパティを使用することで表示位置や表示領域をカスタマイズすることができます。HorizontalOptions プロパティと VerticalOptions プロパティは LayoutOptions 型で以下の値を持ちます。

- Start：開始位置に表示されます。
- Center：中央に表示されます。
- End：終端に表示されます。
- Fill：全体に広がって表示されます。
- StartAndExpand：開始位置に表示され余白を占有します。
- CenterAndExpand：中央に表示され余白を占有します。
- EndAndExpand：終端位置に表示され余白を占有します。
- FillAndExpand：全体に広がって表示され余白を占有します。

動作を確認するための XAML を以下に示します。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:HelloWorld"
             xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core"
             ios:Page.UseSafeArea="true"
             x:Class="HelloWorld.MyPage">
    <StackLayout>
        <BoxView Color="Red"
                 HorizontalOptions="Start" />
        <BoxView Color="Blue"
                 HorizontalOptions="Center" />
        <BoxView Color="Yellow"
                 HorizontalOptions="End" />
        <BoxView Color="Silver"
                 HorizontalOptions="Fill" />
    </StackLayout>
</ContentPage>
```

実行結果を以下にしめします。

![Android StackLayout HorizontalOptions](images/android-stacklayout-horizontaloptions.png)

![iOS StackLayout HorizontalOptions](images/ios-stacklayout-horizontaloptions.png)

***AndExpand は複数指定されると均等に余白を分割しようとします。そのため以下のように複数指定すると均等にコントロールが配置されます。


```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:HelloWorld"
             xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core"
             ios:Page.UseSafeArea="true"
             x:Class="HelloWorld.MyPage">
    <StackLayout>
        <BoxView Color="Red"
                 VerticalOptions="StartAndExpand" />
        <BoxView Color="Blue"
                 VerticalOptions="CenterAndExpand" />
        <BoxView Color="Yellow"
                 VerticalOptions="EndAndExpand" />
        <BoxView Color="Silver"
                 VerticalOptions="FillAndExpand" />
    </StackLayout>
</ContentPage>
```

実行すると以下のようになります。

![Android StackLayout Expand](images/android-stacklayout-expand.png)

![iOS StackLayout Expand](images/ios-stacklayout-expand.png)

画面が 4 分割されて、それぞれ開始位置、中央、終端、いっぱいに広がるというレイアウトがされていることが確認できます。これを組み合わせてネストさせることで複雑なレイアウトが可能になります。複雑なレイアウトの例を以下に示します。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:HelloWorld"
             xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core"
             ios:Page.UseSafeArea="true"
             x:Class="HelloWorld.MyPage">
    <StackLayout VerticalOptions="Start">
        <StackLayout Orientation="Horizontal">
            <BoxView WidthRequest="50"
                     HeightRequest="50"
                     Color="Purple"
                     HorizontalOptions="Center"
                     VerticalOptions="Center" />
            <StackLayout>
                <StackLayout Orientation="Horizontal">
                    <Label Text="名前"
                           FontAttributes="Bold" />
                    <Label Text="@xxxxxxxx" />
                </StackLayout>
                <Label Text="本文本文本文本文本文本文本文本文本文本文本文本文本文本文"
                       VerticalOptions="FillAndExpand" />
                <Label Text="tweeted by sample"
                       VerticalOptions="End" />
            </StackLayout>
        </StackLayout>
    </StackLayout>
</ContentPage>
```

実行すると以下のようになります。ツイッターの1つの呟きのようなレイアウトになります。

![Android StackLayout Complex layout](images/android-stacklayout-complexlayout.png)

![iOS StackLayout Complex layout](images/ios-stacklayout-complexlayout.png)

## Grid

Grid は格子状に領域を区切って、そこにコントロールを配置していく方法でレイアウトを行うコントロールです。RowDefinitions プロパティの中に RowDefinition で行を定義して、ColumnDefinitions プロパティの中に ColumnDefinition を指定して列を定義します。RowDefinition には Height プロパティで高さが指定できます。ColumnDefinition には Width プロパティで幅が指定できます。
Height と Width は GridLength という型で固定数値、Auto、数字*という３つの指定方法があります。Autoが中身の大きさに応じてサイズを変える指定方法で、固定数値が指定したピクセル数で表示する方法になります。数字*という指定方法は、余白を比率で分割する指定方法になります。数字の部分を省略した場合は1を指定したことになります。例えば、「3*」と「2*」を指定すると3:2に領域を分割することになります。コントロールをどこに配置するかは Grid.Row 添付プロパティと Grid.Column 添付プロパティで指定します。インデックスは 0 始まりになります。コード例を以下に示します。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:HelloWorld"
             xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core"
             ios:Page.UseSafeArea="true"
             x:Class="HelloWorld.MyPage">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="50" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
            <RowDefinition Height="2*" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <!-- 指定を省略した時は*になる -->
            <ColumnDefinition Width="100" />
            <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>
        <!-- 何も指定しないと0,0に配置される -->
        <BoxView Color="Purple" />
        <BoxView Color="Red"
                 Grid.Row="1"
                 Grid.Column="1" />
        <BoxView Color="Blue"
                 Grid.Row="2"
                 Grid.Column="2" />
        <BoxView Color="Yellow"
                 Grid.Row="3"
                 Grid.Column="1" />
    </Grid>
</ContentPage>
```

![Android Grid](images/android-grid.png)

![iOS Grid](images/ios-grid.png)


Grid コントロールでは単純にセルの中にコントロールを置くのではなく Grid.RowSpan 添付プロパティと Grid.ColumnSpan 添付プロパティを使って複数のセルに渡って要素を配置することができます。コード例を以下に示します。

```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:HelloWorld"
             xmlns:ios="clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core"
             ios:Page.UseSafeArea="true"
             x:Class="HelloWorld.MyPage">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="50" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
            <RowDefinition Height="2*" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition />
            <!-- 指定を省略した時は*になる -->
            <ColumnDefinition Width="100" />
            <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>
        <BoxView Color="Purple"
                 Grid.RowSpan="3" />
        <!-- 何も指定しないと0,0に配置される -->
        <BoxView Color="Red"
                 Grid.Row="1"
                 Grid.Column="1"
                 Grid.ColumnSpan="2" />
        <BoxView Color="Blue"
                 Grid.Row="2"
                 Grid.Column="2" />
        <BoxView Color="Yellow"
                 Grid.Row="3"
                 Grid.Column="1" />
    </Grid>
</ContentPage>
```

先ほどのコードの一部にGrid.RowSpan添付プロパティとGrid.ColumnSpan添付プロパティを指定しています。実行結果を以下に示します。

![Android Grid span](images/android-grid-span.png)

![iOS Grid span](images/ios-grid-span.png)
