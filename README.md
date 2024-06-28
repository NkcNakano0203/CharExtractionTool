# CharExtractionTool
string配列から重複ナシで文字を抽出してテキストファイルに出力するツールです。  
TMProのTextAssetCreatorへの活用を想定しています。
UPM経由でのインストールはこちら↓  
[https://github.com/NkcNakano0203/CharExtractionTool.git?path=Assets/CharExtractionTool](https://github.com/NkcNakano0203/CharExtractionTool.git?path=CharExtractionTool/Assets/CharExtractionTool)

# 使い方
1. 画面上部のヘッダーメニューの Tool<CharExtractionToolでウィンドウを開きます。  
![image](https://github.com/NkcNakano0203/CharExtractionTool/assets/95272840/aa72621c-adc8-4b02-9ddf-df5b49d710ee)

2. ウィンドウを開いたらUseStringListの要素に使用する単語を追加していきます。  
![image](https://github.com/NkcNakano0203/CharExtractionTool/assets/95272840/1ea68e6b-d2ab-40d8-ac48-fc40052707db)

3. 追加し終わったら`[テキストファイルを生成]`ボタンを押してテキストファイルを出力します。  
![image](https://github.com/NkcNakano0203/CharExtractionTool/assets/95272840/d250aa0d-8231-4cf0-8a7d-ea40dad53e79)
生成が終わるとConsoleウィンドウに出力パスが記載されたログが表示されます。  
保存先は`Assets\CharExtractionTool\TextFile\`です。

# FontAssetCreatorでの使い方
FontAssetCreatorウィンドウの`Character Set`を`Characters from File`にした時に出てくる、  
`Character File`へ生成したテキストファイルをアタッチします。  
![image](https://github.com/NkcNakano0203/CharExtractionTool/assets/95272840/4ae81b0e-4694-4490-b753-2d70776ba15f)  
これで文字の被りがないのでデータ容量が少ないフォントアセットを作成することができます。
