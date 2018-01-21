# research.client
研究実験用のクライアントプログラム

## 環境
 - ### 開発用マシン
  - Windows10 Pro 64bit : v1703 build15063.850
  - Unity : 2017.1.1f1(64bit)
  - [HoloToolkit : v1.2017.1.1](https://github.com/Microsoft/MixedRealityToolkit-Unity/releases/tag/v1.2017.1.1)
  - Visual Studio 2017 : v15.2(26430.6)
 - ### プロトタイプクライアント
  - HoloLens
 - ### プロトタイプサーバ
  - Raspberry Pi 2 model B
 - ### 制御対象家電
  - [Philips Hue](https://www.developers.meethue.com/)


## 事前注意
 - ### HoloLensエミュレータについて
  本研究室に実機が1台有るので使うことは無いと思うが，もしも使う場合は，
  - 開発マシンのOSがWin10 "Pro" Edition以上
  - 仮想化対応のCPU搭載

  の二つの条件を満たしたPCでHyper-Vを有効可する必要がある。  
  そのため，**研究用のPCはデスクトップ型を支給してもらう**ことをお勧めする。  
  あとエミュでは動いたのに実機では動かないことがわりとあるので，
  エミュで動かしただけで満足しないように。

 - ### UnityとMixedRealityToolkit(旧HoloToolKit)について
  MixedRealityToolkitはバージョンアップの際にかなり仕様が変わってしまうことが多い。  
  そのため，**「研究開始時の最新バージョン」もしくは「v1.2017.1.1(動作確認済み)」**を用い，
  **その後のバージョンアップは絶対にしないこと**。  
  また，「バージョンアップの際にかなり仕様が変わってしまう」という理由から，
  インターネット上に出回っている情報が旧バージョンのもので役に立たない事も多いので覚悟すること。


## 開発用マシンの準備
基本的には以下のリンク先に従ってインストールしていけば良い。  
必要なPCスペックも書いてあるので，それに従って支給してもらうこと。  
 - [Windows デベロッパーセンター - Install the tools](https://developer.microsoft.com/ja-jp/windows/mixed-reality/install_the_tools#installation_checklist_for_hololens)  
 - [Qiita - 【Visual Studio 2017】HoloLens の環境構築](https://qiita.com/atsuo1203/items/6732110f6120ecbc2a76)
