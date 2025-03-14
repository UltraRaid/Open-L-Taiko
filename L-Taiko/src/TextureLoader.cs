public class TextureLoader {
	// ...existing code...
	public static void LoadTexture(Action<int> progressCallback) {
		int totalTextures = 100; // 仮の総テクスチャ数
		for (int i = 0; i < totalTextures; i++) {
			// テクスチャ読み込み処理
			// ...existing code...
			progressCallback?.Invoke((i + 1) * 100 / totalTextures);
		}
	}
	// ...existing code...
}
