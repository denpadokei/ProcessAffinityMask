# ProcessAffinityMask

Beat Saber 用の BSIPA プラグイン。プロセスの CPU アフィニティマスク（CPU コアの使用設定）を制御し、ゲームのパフォーマンスを最適化します。

## 概要

ProcessAffinityMask は、Beat Saber プロセスが使用する CPU コアを指定できるプラグインです。マルチコア CPU 環境において、特定の CPU コアをゲームに割り当てることで、システムリソースの効率的な使用やパフォーマンスの向上を実現できます。

## 機能

- CPU コアの選択的割り当て
- プロセスアフィニティマスクの動的制御
- 設定ファイルによる簡単なカスタマイズ

## 動作環境

- Beat Saber
- BSIPA 4.3.6 以上
- .NET Framework 4.8

## インストール

1. [リリースページ](https://github.com/denpadokei/ProcessAffinityMask/releases)から最新版をダウンロード
2. `ProcessAffinityMask.dll` を Beat Saber の `Plugins` フォルダに配置

## 設定

プラグインの設定は `Beat Saber\UserData\ProcessAffinityMask.json` で行えます。

### デフォルト設定例

```json
{
  "useCPUCoreNumbers": [0, 1, 2, 3]
}
```

### 設定項目

- **useCPUCoreNumbers**: 使用する CPU コアの番号リスト（0 から始まるインデックス）
  - 例: `[0, 1, 2, 3]` → コア 0, 1, 2, 3 を使用
  - 例: `[0, 2, 4]` → コア 0, 2, 4 を使用

## 使用例

CPU コアを限定したい場合、`useCPUCoreNumbers` を編集します：

```json
{
  "useCPUCoreNumbers": [0, 1]
}
```

## トラブルシューティング

設定が反映されない場合は、Beat Saber を完全に再起動してください。

## ライセンス

このプロジェクトはオープンソースです。

## 作者

denpadokei

## サポート

問題が発生した場合は、[GitHub Issues](https://github.com/denpadokei/ProcessAffinityMask/issues) でお知らせください。