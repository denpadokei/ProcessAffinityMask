# ProcessAffinityMask

[![Build and Release](https://github.com/denpadokei/ProcessAffinityMask/actions/workflows/build-and-release.yml/badge.svg)](https://github.com/denpadokei/ProcessAffinityMask/actions/workflows/build-and-release.yml)

Beat Saber のプロセスに CPU アフィニティマスクを設定し、使用する CPU コアを指定できる MOD です。マルチコア CPU で特定のコアだけを使わせたい場合に利用します。

## 機能

- ゲーム起動時に Beat Saber プロセスのアフィニティマスクを設定
- 使用する CPU コア番号を 0 始まりのインデックスで指定
- 範囲外のコア番号は警告をログに出してスキップ
- 設定したコアが 1 つも無い場合はアフィニティを変更しない
- 設定の適用結果と失敗時のエラーコードをログに出力

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.39.1 |
| 依存 MOD | BSIPA 4.3.6 |

## インストール

1. Beat Saber を 1.39.1 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/ProcessAffinityMask/releases) から `ProcessAffinityMask-0.0.1-bs1.39.1.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## 使い方

使用する CPU コアを変えたい場合は、`UserData/ProcessAffinityMask.json` の `UseCPUCoreNumbers` を編集します。

```json
{
  "UseCPUCoreNumbers": [0, 1]
}
```

アフィニティはゲーム起動時に一度だけ設定されるため、変更後は Beat Saber を完全に再起動してください。

## 設定

| 項目 | 型 | 既定値 | 説明 |
| --- | --- | --- | --- |
| UseCPUCoreNumbers | List\<int\> | [0, 1, 2, 3] | 使用する CPU コア番号のリスト (0 始まり)。例: `[0, 2, 4]` でコア 0, 2, 4 のみ使用 |

設定は `UserData/ProcessAffinityMask.json` に保存されます。

## ビルド

```powershell
git clone https://github.com/denpadokei/ProcessAffinityMask.git
cd ProcessAffinityMask
dotnet build .\ProcessAffinityMask\ProcessAffinityMask.csproj -c Release
```

csproj は `..\Refs` が存在すればそこを参照先にします。`BeatSaberDir` に Beat Saber のインストール先を設定すると、ゲームの参照アセンブリを解決できます。

GitHub Actions の `build-and-release.yml` が push ごとにビルドし、`X.X.X` 形式のタグを push するとリリースを作成します。

## ライセンス

MIT
