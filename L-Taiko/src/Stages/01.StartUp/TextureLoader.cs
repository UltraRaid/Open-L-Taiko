﻿using System.Diagnostics;
using FDK;

namespace OpenTaiko;

class TextureLoader {
	public static string BASE = @$"Graphics{Path.DirectorySeparatorChar}";
	public static string GLOBAL = @$"Global{Path.DirectorySeparatorChar}";

	// Global assets
	public static string PUCHICHARA = @$"PuchiChara{Path.DirectorySeparatorChar}";
	public static string CHARACTERS = @$"Characters{Path.DirectorySeparatorChar}";

	// Stage
	public static string STARTUP = @$"0_Startup{Path.DirectorySeparatorChar}";
	public static string TITLE = @$"1_Title{Path.DirectorySeparatorChar}";
	public static string CONFIG = @$"2_Config{Path.DirectorySeparatorChar}";
	public static string SONGSELECT = @$"3_SongSelect{Path.DirectorySeparatorChar}";
	public static string DANISELECT = @$"3_DaniSelect{Path.DirectorySeparatorChar}";
	public static string SONGLOADING = @$"4_SongLoading{Path.DirectorySeparatorChar}";
	public static string GAME = @$"5_Game{Path.DirectorySeparatorChar}";
	public static string RESULT = @$"6_Result{Path.DirectorySeparatorChar}";
	public static string EXIT = @$"7_Exit{Path.DirectorySeparatorChar}";
	public static string DANRESULT = @$"7_DanResult{Path.DirectorySeparatorChar}";
	public static string TOWERRESULT = @$"8_TowerResult{Path.DirectorySeparatorChar}";
	public static string HEYA = @$"10_Heya{Path.DirectorySeparatorChar}";

	public static string MODALS = @$"11_Modals{Path.DirectorySeparatorChar}";
	public static string ONLINELOUNGE = @$"12_OnlineLounge{Path.DirectorySeparatorChar}";
	public static string TOWERSELECT = @$"13_TowerSelect{Path.DirectorySeparatorChar}";

	// InGame
	public static string DANCER = @$"2_Dancer{Path.DirectorySeparatorChar}";
	public static string MOB = @$"3_Mob{Path.DirectorySeparatorChar}";
	public static string COURSESYMBOL = @$"4_CourseSymbol{Path.DirectorySeparatorChar}";
	public static string BACKGROUND = @$"5_Background{Path.DirectorySeparatorChar}";
	public static string TAIKO = @$"6_Taiko{Path.DirectorySeparatorChar}";
	public static string GAUGE = @$"7_Gauge{Path.DirectorySeparatorChar}";
	public static string FOOTER = @$"8_Footer{Path.DirectorySeparatorChar}";
	public static string END = @$"9_End{Path.DirectorySeparatorChar}";
	public static string EFFECTS = @$"10_Effects{Path.DirectorySeparatorChar}";
	public static string BALLOON = @$"11_Balloon{Path.DirectorySeparatorChar}";
	public static string LANE = @$"12_Lane{Path.DirectorySeparatorChar}";
	public static string GENRE = @$"13_GENRE{Path.DirectorySeparatorChar}";
	public static string GAMEMODE = @$"14_GameMode{Path.DirectorySeparatorChar}";
	public static string FAILED = @$"15_Failed{Path.DirectorySeparatorChar}";
	public static string RUNNER = @$"16_Runner{Path.DirectorySeparatorChar}";
	public static string TRAINING = @$"19_Training{Path.DirectorySeparatorChar}";
	public static string DANC = @$"17_DanC{Path.DirectorySeparatorChar}";
	public static string TOWER = @$"20_Tower{Path.DirectorySeparatorChar}";
	public static string MODICONS = @$"21_ModIcons{Path.DirectorySeparatorChar}";
	public static string AIBATTLE = @$"22_AIBattle{Path.DirectorySeparatorChar}";

	// Special balloons
	public static string KUSUDAMA = @$"Kusudama{Path.DirectorySeparatorChar}";
	public static string FUSE = @$"Fuseroll{Path.DirectorySeparatorChar}";

	// Tower infos
	public static string TOWERDON = @$"Tower_Don{Path.DirectorySeparatorChar}";
	public static string TOWERFLOOR = @$"Tower_Floors{Path.DirectorySeparatorChar}";

	// InGame_Effects
	public static string FIRE = @$"Fire{Path.DirectorySeparatorChar}";
	public static string HIT = @$"Hit{Path.DirectorySeparatorChar}";
	public static string ROLL = @$"Roll{Path.DirectorySeparatorChar}";
	public static string SPLASH = @$"Splash{Path.DirectorySeparatorChar}";

	public Dictionary<string, CTexture> trackedTextures = new Dictionary<string, CTexture>();

	public TextureLoader() {
		// Constructor
	}

	internal CTexture TxC(string FileName, bool localize = true) {
		var texpath = (localize) ? HLocalizedPath.GetAvailableLocalizedPath(CSkin.Path(BASE + FileName)) : CSkin.Path(BASE + FileName);
		var tex = OpenTaiko.tテクスチャの生成(texpath, false);

		listTexture.Add(tex);
		return tex;
	}

	internal CTexture TxCGlobal(string FileName) {
		var tex = OpenTaiko.tテクスチャの生成(OpenTaiko.strEXEのあるフォルダ + GLOBAL + FileName, false);
		listTexture.Add(tex);
		return tex;
	}

	internal CTexture TxCAbsolute(string FileName) {
		var tex = OpenTaiko.tテクスチャの生成(FileName, false);
		listTexture.Add(tex);
		return tex;
	}

	internal CTextureAf TxCAf(string FileName) {
		var tex = OpenTaiko.tテクスチャの生成Af(CSkin.Path(BASE + FileName));
		listTexture.Add(tex);
		return tex;
	}
	internal CTexture TxCGen(string FileName) {
		return OpenTaiko.tテクスチャの生成(CSkin.Path(BASE + GAME + GENRE + FileName + ".png"), false);
	}

	internal CTexture TxCSong(string path) {
		return TxCUntrackedSong(path);
	}

	private CTexture[] TxCSong(int count, string format, int start = 0) {
		return TxCSong(format, Enumerable.Range(start, count).Select(o => o.ToString()).ToArray());
	}

	private CTexture[] TxCSong(string format, params string[] parts) {
		return parts.Select(o => TxCSong(string.Format(format, o))).ToArray();
	}

	public CTexture[] TxCSongFolder(string folder) {
		var count = OpenTaiko.t連番画像の枚数を数える(folder);
		var texture = count == 0 ? null : TxCSong(count, folder + "{0}.png");
		return texture;
	}

	internal CTexture TxCUntrackedSong(string path) {
		return OpenTaiko.tテクスチャの生成(path, false);
	}

	public void LoadTexture() {
		CalibrateFG = TxC(CONFIG + $@"Calibration{Path.DirectorySeparatorChar}FG.png");
		CalibrateBG = TxC(CONFIG + $@"Calibration{Path.DirectorySeparatorChar}BG.png");

		#region 共通
		Tile_Black = TxC(@$"Tile_Black.png");
		Menu_Title = TxC(@$"Menu_Title.png");
		Menu_Highlight = TxC(@$"Menu_Highlight.png");
		Enum_Song = TxC(@$"Enum_Song.png");
		Loading = TxC(@$"Loading.png");
		Scanning_Loudness = TxC(@$"Scanning_Loudness.png");
		Overlay = TxC(@$"Overlay.png");
		Network_Connection = TxC(@$"Network_Connection.png");
		Readme = TxC(@$"Readme.png");
		NamePlateBase = TxC(@$"NamePlate.png");
		NamePlate_Extension = TxC(@$"NamePlate_Extension.png");

		#endregion

		#region 1_タイトル画面
		Entry_Bar = TxC(TITLE + @$"Entry_Bar.png");
		Entry_Bar_Text = TxC(TITLE + @$"Entry_Bar_Text.png");

		Banapas_Load[0] = TxC(TITLE + @$"Banapas_Load.png");
		Banapas_Load[1] = TxC(TITLE + @$"Banapas_Load_Text.png");
		Banapas_Load[2] = TxC(TITLE + @$"Banapas_Load_Anime.png");

		Banapas_Load_Clear[0] = TxC(TITLE + @$"Banapas_Load_Clear.png");
		Banapas_Load_Clear[1] = TxC(TITLE + @$"Banapas_Load_Clear_Anime.png");

		Entry_Player[0] = TxC(TITLE + @$"Entry_Player.png");
		Entry_Player[1] = TxC(TITLE + @$"Entry_Player_Select_Bar.png");
		Entry_Player[2] = TxC(TITLE + @$"Entry_Player_Select.png");

		ModeSelect_Bar = new CTexture[CMainMenuTab.__MenuCount + 1];
		ModeSelect_Bar_Chara = new CTexture[CMainMenuTab.__MenuCount];

		for (int i = 0; i < CMainMenuTab.__MenuCount; i++) {
			ModeSelect_Bar[i] = TxC(TITLE + @$"ModeSelect_Bar_" + i.ToString() + ".png");
		}

		for (int i = 0; i < CMainMenuTab.__MenuCount; i++) {
			ModeSelect_Bar_Chara[i] = TxC(TITLE + @$"ModeSelect_Bar_Chara_" + i.ToString() + ".png");
		}

		ModeSelect_Bar[CMainMenuTab.__MenuCount] = TxC(TITLE + @$"ModeSelect_Bar_Overlay.png");

		#endregion

		#region 2_コンフィグ画面
		//Config_Background = TxC(CONFIG + @$"Background.png");
		//Config_Header = TxC(CONFIG + @$"Header.png");
		Config_Cursor = TxC(CONFIG + @$"Cursor.png");
		Config_ItemBox = TxC(CONFIG + @$"ItemBox.png");
		Config_Arrow = TxC(CONFIG + @$"Arrow.png");
		Config_KeyAssign = TxC(CONFIG + @$"KeyAssign.png");
		Config_Font = TxC(CONFIG + @$"Font.png");
		Config_Font_Bold = TxC(CONFIG + @$"Font_Bold.png");
		Config_Enum_Song = TxC(CONFIG + @$"Enum_Song.png");
		#endregion

		#region 3_選曲画面
		SongSelect_Background = TxC(SONGSELECT + @$"Background.png");
		SongSelect_Header = TxC(SONGSELECT + @$"Header.png");
		SongSelect_Footer = TxC(SONGSELECT + @$"Footer.png");
		SongSelect_Coin_Slot[0] = TxC(SONGSELECT + @$"Coin_Slot.png");
		SongSelect_Coin_Slot[1] = TxC(SONGSELECT + @$"Coin_Slot_3P.png");
		SongSelect_Coin_Slot[2] = TxC(SONGSELECT + @$"Coin_Slot_4P.png");
		SongSelect_Coin_Slot[3] = TxC(SONGSELECT + @$"Coin_Slot_5P.png");

		SongSelect_Level = TxC(SONGSELECT + @$"Level.png");
		SongSelect_Branch = TxC(SONGSELECT + @$"Branch.png");
		SongSelect_Branch_Text = TxC(SONGSELECT + @$"Branch_Text.png");
		SongSelect_Bar_Center = TxC(SONGSELECT + @$"Bar_Center.png");
		SongSelect_Lock = TxC(SONGSELECT + @$"Lock.png");

		SongSelect_Frame_Score[0] = TxC(SONGSELECT + @$"Frame_Score.png");
		SongSelect_Frame_Score[1] = TxC(SONGSELECT + @$"Frame_Score_Tower.png");
		SongSelect_Frame_Score[2] = TxC(SONGSELECT + @$"Frame_Score_Dan.png");

		SongSelect_Tower_Side = TxC(SONGSELECT + @$"Tower_Side.png");

		SongSelect_Frame_Box = TxC(SONGSELECT + @$"Frame_Box.png");
		SongSelect_Frame_BackBox = TxC(SONGSELECT + @$"Frame_BackBox.png");
		SongSelect_Frame_Random = TxC(SONGSELECT + @$"Frame_Random.png");
		SongSelect_Bar_Genre_Back = TxC(SONGSELECT + @$"Bar_Genre_Back.png");
		SongSelect_Bar_Genre_Locked = TxC(SONGSELECT + @$"Bar_Genre_Locked.png");
		SongSelect_Bar_Genre_Locked_Top = TxC(SONGSELECT + @$"Bar_Genre_Locked_Top.png");
		SongSelect_Bar_Genre_Random = TxC(SONGSELECT + @$"Bar_Genre_Random.png");
		SongSelect_Bar_Genre_RecentryPlaySong = TxC(SONGSELECT + @$"Bar_Genre_RecentryPlaySong.png");
		SongSelect_Bar_Select = TxC(SONGSELECT + @$"Bar_Select.png");
		SongSelect_Level_Number = TxC(SONGSELECT + @$"Level_Number.png");
		SongSelect_Level_Number_Big = TxC(SONGSELECT + @$"Level_Number_Big.png");
		SongSelect_Level_Number_Big_Colored = TxC(SONGSELECT + @$"Level_Number_Big_Colored.png");
		SongSelect_Level_Number_Colored = TxC(SONGSELECT + @$"Level_Number_Colored.png");
		SongSelect_Level_Number_Big_Icon = TxC(SONGSELECT + @$"Level_Number_Big_Icon.png");
		SongSelect_Level_Number_Icon = TxC(SONGSELECT + @$"Level_Number_Icon.png");
		SongSelect_Bpm_Number = TxC(SONGSELECT + @$"Bpm_Number.png");
		SongSelect_Floor_Number = TxC(SONGSELECT + @$"Floor_Number.png");
		SongSelect_Credit = TxC(SONGSELECT + @$"Credit.png");
		SongSelect_Timer = TxC(SONGSELECT + @$"Timer.png");
		SongSelect_Explicit = TxC(SONGSELECT + @$"Explicit.png");
		SongSelect_Movie = TxC(SONGSELECT + @$"Movie.png");
		SongSelect_Song_Number = TxC(SONGSELECT + @$"Song_Number.png");
		SongSelect_Bar_Genre_Overlay = TxC(SONGSELECT + @$"Bar_Genre_Overlay.png");
		SongSelect_Crown = TxC(SONGSELECT + @$"SongSelect_Crown.png");
		SongSelect_ScoreRank = TxC(SONGSELECT + @$"ScoreRank.png");
		SongSelect_BoardNumber = TxC(SONGSELECT + @$"BoardNumber.png");
		SongSelect_Difficulty_Cymbol = TxC(SONGSELECT + "Difficulty_Cymbol.png");
		SongSelect_Unlock_Conditions = TxC(SONGSELECT + "Unlock_Conditions.png");

		SongSelect_Favorite = TxC(SONGSELECT + @$"Favorite.png");
		SongSelect_High_Score = TxC(SONGSELECT + @$"High_Score.png");

		SongSelect_Level_Icons = TxC(SONGSELECT + @$"Level_Icons.png");
		SongSelect_Search_Arrow = TxC(SONGSELECT + @$"Search{Path.DirectorySeparatorChar}Search_Arrow.png");
		SongSelect_Search_Arrow_Glow = TxC(SONGSELECT + @$"Search{Path.DirectorySeparatorChar}Search_Arrow_Glow.png");
		SongSelect_Search_Window = TxC(SONGSELECT + @$"Search{Path.DirectorySeparatorChar}Search_Window.png");

		for (int i = 0; i < (int)Difficulty.Total; i++) {
			SongSelect_ScoreWindow[i] = TxC(SONGSELECT + @$"ScoreWindow_" + i.ToString() + ".png");
		}

		SongSelect_ScoreWindow_Text = TxC(SONGSELECT + @$"ScoreWindow_Text.png");



		{
			string[] genre_files = Directory.GetFiles(CSkin.Path(BASE + SONGSELECT + @$"Bar_Genre{Path.DirectorySeparatorChar}"), "Bar_Genre_*.png");
			SongSelect_Bar_Genre = new();
			for (int i = 0; i < genre_files.Length; i++) {
				string name = Path.GetFileNameWithoutExtension(genre_files[i]).Split('_')[2];
				if (name != "Overlap") SongSelect_Bar_Genre.Add(name, TxC(SONGSELECT + @$"Bar_Genre{Path.DirectorySeparatorChar}Bar_Genre_" + name + ".png"));
			}
		}
		{
			string[] genre_files = Directory.GetFiles(CSkin.Path(BASE + SONGSELECT + @$"Bar_Genre{Path.DirectorySeparatorChar}"), "Bar_Genre_Overlap_*.png");
			SongSelect_Bar_Genre_Overlap = new();
			for (int i = 0; i < genre_files.Length; i++) {
				string name = Path.GetFileNameWithoutExtension(genre_files[i]).Split('_')[3];
				SongSelect_Bar_Genre_Overlap.Add(name, TxC(SONGSELECT + @$"Bar_Genre{Path.DirectorySeparatorChar}Bar_Genre_Overlap_" + name + ".png"));
			}
		}

		{
			string[] genre_files = Directory.GetFiles(CSkin.Path(BASE + SONGSELECT + @$"Genre_Background{Path.DirectorySeparatorChar}"), "GenreBackground_*.png");
			SongSelect_GenreBack = new();
			for (int i = 0; i < genre_files.Length; i++) {
				string name = Path.GetFileNameWithoutExtension(genre_files[i]).Split('_')[1];
				SongSelect_GenreBack.Add(name, TxC(SONGSELECT + @$"Genre_Background{Path.DirectorySeparatorChar}GenreBackground_" + name + ".png"));
			}
		}

		{
			string[] genre_files = Directory.GetFiles(CSkin.Path(BASE + SONGSELECT + @$"Box_Chara{Path.DirectorySeparatorChar}"), "Box_Chara_*.png");
			SongSelect_Box_Chara = new();
			for (int i = 0; i < genre_files.Length; i++) {
				string name = Path.GetFileNameWithoutExtension(genre_files[i]).Split('_')[2];
				SongSelect_Box_Chara.Add(name, TxC(SONGSELECT + @$"Box_Chara{Path.DirectorySeparatorChar}Box_Chara_" + name + ".png"));
			}
		}

		for (int i = 0; i < SongSelect_Table.Length; i++) {
			SongSelect_Table[i] = TxC(SONGSELECT + @$"Table{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
		}

		SongSelect_Song_Panel[0] = TxC(SONGSELECT + @$"Song_Panel{Path.DirectorySeparatorChar}Song_Panel_Box.png");
		SongSelect_Song_Panel[1] = TxC(SONGSELECT + @$"Song_Panel{Path.DirectorySeparatorChar}Song_Panel_Song.png");
		SongSelect_Song_Panel[2] = TxC(SONGSELECT + @$"Song_Panel{Path.DirectorySeparatorChar}Song_Panel_Dan.png");
		SongSelect_Song_Panel[3] = TxC(SONGSELECT + @$"Song_Panel{Path.DirectorySeparatorChar}Song_Panel_Tower.png");
		SongSelect_Song_Panel[4] = TxC(SONGSELECT + @$"Song_Panel{Path.DirectorySeparatorChar}Song_Panel_Locked_Song.png");
		SongSelect_Song_Panel[5] = TxC(SONGSELECT + @$"Song_Panel{Path.DirectorySeparatorChar}Song_Panel_Locked_Asset.png");

		#region [ 難易度選択画面 ]
		Difficulty_Bar = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Bar.png");
		Difficulty_Number = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Number.png");
		Difficulty_Number_Colored = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Number_Colored.png");
		Difficulty_Number_Icon = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Number_Icon.png");
		Difficulty_Star = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Star.png");
		Difficulty_Crown = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Crown.png");
		Difficulty_Option = TxC($"{SONGSELECT}Difficulty_Select/Difficulty_Option.png");
		Difficulty_Option_Select = TxC($"{SONGSELECT}Difficulty_Select/Difficulty_Option_Select.png");

		Difficulty_Select_Bar[0] = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Select_Bar.png");
		Difficulty_Select_Bar[1] = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Select_Bar2.png");
		Difficulty_Select_Bar[2] = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Select_Bar3.png");
		Difficulty_Select_Bar[3] = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Select_Bar4.png");
		Difficulty_Select_Bar[4] = TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Select_Bar5.png");

		{
			string[] genre_files = Directory.GetFiles(CSkin.Path(BASE + SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Back{Path.DirectorySeparatorChar}"), "Difficulty_Back_*.png");
			Difficulty_Back = new();
			for (int i = 0; i < genre_files.Length; i++) {
				string name = Path.GetFileNameWithoutExtension(genre_files[i]).Split('_')[2];
				Difficulty_Back.Add(name, TxC(SONGSELECT + @$"Difficulty_Select{Path.DirectorySeparatorChar}Difficulty_Back{Path.DirectorySeparatorChar}Difficulty_Back_" + name + ".png"));
			}
		}
		#endregion

		NewHeya_Close = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}Close.png");
		NewHeya_Close_Select = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}Close_Select.png");
		NewHeya_PlayerPlate[0] = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}PlayerPlate_1P.png");
		NewHeya_PlayerPlate[1] = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}PlayerPlate_2P.png");
		NewHeya_PlayerPlate[2] = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}PlayerPlate_3P.png");
		NewHeya_PlayerPlate[3] = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}PlayerPlate_4P.png");
		NewHeya_PlayerPlate[4] = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}PlayerPlate_5P.png");
		NewHeya_PlayerPlate_Select = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}PlayerPlate_Select.png");
		NewHeya_ModeBar = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}ModeBar.png");
		NewHeya_ModeBar_Select = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}ModeBar_Select.png");
		NewHeya_Box = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}Box.png");
		NewHeya_Lock = TxC(SONGSELECT + @$"NewHeya{Path.DirectorySeparatorChar}Lock.png");

		#endregion

		#region 3_段位選択画面

		//Dani_Background = TxC(DANISELECT + "Background.png");
		Dani_Difficulty_Cymbol = TxC(DANISELECT + "Difficulty_Cymbol.png");
		Dani_Level_Number = TxC(DANISELECT + "Level_Number.png");
		Dani_Soul_Number = TxC(DANISELECT + "SoulNumber.png");
		Dani_Exam_Number = TxC(DANISELECT + "ExamNumber.png");
		Dani_Bar_Center = TxC(DANISELECT + "Bar_Center.png");
		Dani_Bar_Back = TxC(DANISELECT + "Bar_Back.png");
		Dani_Bar_Folder = TxC(DANISELECT + "Bar_Folder.png");
		Dani_Bar_Folder_Back = TxC(DANISELECT + "Bar_Folder_Back.png");
		Dani_Bar_Random = TxC(DANISELECT + "Bar_Random.png");
		Dani_Plate = TxC(DANISELECT + "Plate.png");
		Dani_Plate_Extra = TxC(DANISELECT + "Plate_Extra.png");

		for (int i = 0; i < Challenge_Select.Length; i++)
			Challenge_Select[i] = TxC(DANISELECT + "Challenge_Select_" + i.ToString() + ".png");

		//Dani_Dan_In = TxC(DANISELECT + "Dan_In.png");
		//Dani_Dan_Text = TxC(DANISELECT + "Dan_Text.png");

		Dani_DanPlates = TxC(DANISELECT + "DanPlates.png");
		Dani_DanPlates_Back = TxC(DANISELECT + "DanPlates_Back.png");
		Dani_DanIcon = TxC(DANISELECT + "DanIcon.png");
		Dani_DanIcon_Fade = TxC(DANISELECT + "DanIcon_Fade.png");
		Dani_DanSides = TxC(DANISELECT + "DanSides.png");

		for (int i = 0; i < Dani_Bloc.Length; i++)
			Dani_Bloc[i] = TxC(DANISELECT + "Bloc" + i.ToString() + ".png");

		#endregion

		#region 4_読み込み画面

		SongLoading_Plate = TxC(SONGLOADING + @$"Plate.png");
		SongLoading_Bg = TxC(SONGLOADING + @$"Bg.png");
		SongLoading_BgWait = TxC(SONGLOADING + @$"Bg_Wait.png");
		SongLoading_Chara = TxC(SONGLOADING + @$"Chara.png");
		SongLoading_Fade = TxC(SONGLOADING + @$"Fade.png");
		SongLoading_Bg_Dan = TxC(SONGLOADING + @$"Bg_Dan.png");

		SongLoading_Plate_AI = TxC(SONGLOADING + @$"Plate_AI.png");
		SongLoading_Bg_AI = TxC(SONGLOADING + @$"Bg_AI.png");
		SongLoading_Bg_AI_Wait = TxC(SONGLOADING + @$"Bg_AI_Wait.png");
		SongLoading_Fade_AI = TxC(SONGLOADING + @$"Fade_AI.png");
		SongLoading_Fade_AI_Anime_Base = TxC(SONGLOADING + @$"Fade_AI_Anime_Base.png");
		SongLoading_Fade_AI_Anime_Ring = TxC(SONGLOADING + @$"Fade_AI_Anime_Ring.png");
		SongLoading_Fade_AI_Anime_NowLoading = TxC(SONGLOADING + @$"Fade_AI_Anime_NowLoading.png");
		SongLoading_Fade_AI_Anime_Start = TxC(SONGLOADING + @$"Fade_AI_Anime_Start.png");
		SongLoading_Fade_AI_Anime_LoadBar_Base = TxC(SONGLOADING + @$"Fade_AI_Anime_LoadBar_Base.png");
		SongLoading_Fade_AI_Anime_LoadBar = TxC(SONGLOADING + @$"Fade_AI_Anime_LoadBar.png");

		#endregion

		#region 5_演奏画面

		#region General

		Notes = new CTexture[2];
		Notes[0] = TxC(GAME + @$"Notes.png");
		Notes[1] = TxC(GAME + @$"Notes_Konga.png");

		Note_Mine = TxC(GAME + @$"Mine.png");
		Note_Swap = TxC(GAME + @$"Swap.png");
		Note_Kusu = TxC(GAME + @$"Kusu.png");
		Note_FuseRoll = TxC(GAME + @$"FuseRoll.png");
		Note_Adlib = TxC(GAME + @$"Adlib.png");

		Judge_Frame = TxC(GAME + @$"Notes.png");

		SENotes = new CTexture[2];
		SENotes[0] = TxC(GAME + @$"SENotes.png");
		SENotes[1] = TxC(GAME + @$"SENotes_Konga.png");

		SENotesExtension = TxC(GAME + @$"SENotes_Extension.png");

		Notes_Arm = TxC(GAME + @$"Notes_Arm.png");
		Judge = TxC(GAME + @$"Judge.png");
		ChipEffect = TxC(GAME + @$"ChipEffect.png");
		ScoreRank = TxC(GAME + @$"ScoreRank.png");

		Judge_Meter = TxC(GAME + @$"Judge_Meter.png");
		Bar = TxC(GAME + @$"Bar.png");
		Bar_Branch = TxC(GAME + @$"Bar_Branch.png");

		var _presetsDefs = CSkin.Path(BASE + GAME + BACKGROUND + @$"Presets.json");
		if (File.Exists(_presetsDefs))
			OpenTaiko.Skin.Game_SkinScenes = ConfigManager.GetConfig<DBSkinPreset.SkinPreset>(_presetsDefs);
		else
			OpenTaiko.Skin.Game_SkinScenes = new DBSkinPreset.SkinPreset();

		#endregion

		#region Taiko

		Taiko_Background = new CTexture[12];
		Taiko_Background[0] = TxC(GAME + TAIKO + @$"1P_Background.png");
		Taiko_Background[1] = TxC(GAME + TAIKO + @$"2P_Background.png");
		Taiko_Background[2] = TxC(GAME + TAIKO + @$"Dan_Background.png");
		Taiko_Background[3] = TxC(GAME + TAIKO + @$"Tower_Background.png");
		Taiko_Background[4] = TxC(GAME + TAIKO + @$"1P_Background_Right.png");
		Taiko_Background[5] = TxC(GAME + TAIKO + @$"1P_Background_Tokkun.png");
		Taiko_Background[6] = TxC(GAME + TAIKO + @$"2P_Background_Tokkun.png");
		Taiko_Background[7] = TxC(GAME + TAIKO + @$"3P_Background.png");
		Taiko_Background[8] = TxC(GAME + TAIKO + @$"4P_Background.png");
		Taiko_Background[9] = TxC(GAME + TAIKO + @$"AI_Background.png");
		Taiko_Background[10] = TxC(GAME + TAIKO + @$"Boss_Background.png");
		Taiko_Background[11] = TxC(GAME + TAIKO + @$"5P_Background.png");

		Taiko_Frame = new CTexture[7];
		Taiko_Frame[0] = TxC(GAME + TAIKO + @$"1P_Frame.png");
		Taiko_Frame[1] = TxC(GAME + TAIKO + @$"2P_Frame.png");
		Taiko_Frame[2] = TxC(GAME + TAIKO + @$"Tower_Frame.png");
		Taiko_Frame[3] = TxC(GAME + TAIKO + @$"Tokkun_Frame.png");
		Taiko_Frame[4] = TxC(GAME + TAIKO + @$"2P_None_Frame.png");
		Taiko_Frame[5] = TxC(GAME + TAIKO + @$"AI_Frame.png");
		Taiko_Frame[6] = TxC(GAME + TAIKO + @$"4PPlay_Frame.png");

		Taiko_PlayerNumber = new CTexture[5];
		Taiko_PlayerNumber[0] = TxC(GAME + TAIKO + @$"1P_PlayerNumber.png");
		Taiko_PlayerNumber[1] = TxC(GAME + TAIKO + @$"2P_PlayerNumber.png");
		Taiko_PlayerNumber[2] = TxC(GAME + TAIKO + @$"3P_PlayerNumber.png");
		Taiko_PlayerNumber[3] = TxC(GAME + TAIKO + @$"4P_PlayerNumber.png");
		Taiko_PlayerNumber[4] = TxC(GAME + TAIKO + @$"5P_PlayerNumber.png");


		Taiko_Base = new CTexture[2];
		Taiko_Base[0] = TxC(GAME + TAIKO + @$"Base.png");
		Taiko_Base[1] = TxC(GAME + TAIKO + @$"Base_Konga.png");

		Taiko_Don_Left = TxC(GAME + TAIKO + @$"Don_Left.png");
		Taiko_Don_Right = TxC(GAME + TAIKO + @$"Don_Right.png");
		Taiko_Ka_Left = TxC(GAME + TAIKO + @$"Ka_Left.png");
		Taiko_Ka_Right = TxC(GAME + TAIKO + @$"Ka_Right.png");

		Taiko_Konga_Don = TxC(GAME + TAIKO + @$"Don_Konga.png");
		Taiko_Konga_Ka = TxC(GAME + TAIKO + @$"Ka_Konga.png");
		Taiko_Konga_Clap = TxC(GAME + TAIKO + @$"Clap.png");

		Taiko_LevelUp = TxC(GAME + TAIKO + @$"LevelUp.png");
		Taiko_LevelDown = TxC(GAME + TAIKO + @$"LevelDown.png");
		Couse_Symbol = new CTexture[(int)Difficulty.Total + 1]; // +1は真打ちモードの分
		Couse_Symbol_Back = new CTexture[(int)Difficulty.Total + 1]; // +1は真打ちモードの分
		Couse_Symbol_Back_Flash = new CTexture[(int)Difficulty.Total + 1]; // +1は真打ちモードの分
		string[] Couse_Symbols = new string[(int)Difficulty.Total + 1] { "Easy", "Normal", "Hard", "Oni", "Edit", "Tower", "Dan", "Shin" };
		for (int i = 0; i < (int)Difficulty.Total + 1; i++) {
			Couse_Symbol[i] = TxC(GAME + COURSESYMBOL + Couse_Symbols[i] + ".png");
			Couse_Symbol_Back[i] = TxC(GAME + COURSESYMBOL + Couse_Symbols[i] + "_Back.png");
			Couse_Symbol_Back_Flash[i] = TxC(GAME + COURSESYMBOL + Couse_Symbols[i] + "_Back_Flash.png");
		}

		Taiko_Score = new CTexture[6];
		Taiko_Score[0] = TxC(GAME + TAIKO + @$"Score.png");
		Taiko_Score[1] = TxC(GAME + TAIKO + @$"Score_1P.png");
		Taiko_Score[2] = TxC(GAME + TAIKO + @$"Score_2P.png");
		Taiko_Score[3] = TxC(GAME + TAIKO + @$"Score_3P.png");
		Taiko_Score[4] = TxC(GAME + TAIKO + @$"Score_4P.png");
		Taiko_Score[5] = TxC(GAME + TAIKO + @$"Score_5P.png");
		Taiko_Combo = new CTexture[4];
		Taiko_Combo[0] = TxC(GAME + TAIKO + @$"Combo.png");
		Taiko_Combo[1] = TxC(GAME + TAIKO + @$"Combo_Big.png");
		Taiko_Combo[2] = TxC(GAME + TAIKO + @$"Combo_Midium.png");
		Taiko_Combo[3] = TxC(GAME + TAIKO + @$"Combo_Huge.png");
		Taiko_Combo_Effect = TxC(GAME + TAIKO + @$"Combo_Effect.png");
		Taiko_Combo_Text = TxC(GAME + TAIKO + @$"Combo_Text.png");

		Taiko_Combo_Guide = new CTexture[3];
		for (int i = 0; i < Taiko_Combo_Guide.Length; i++) {
			Taiko_Combo_Guide[i] = TxC(GAME + TAIKO + @$"Combo_Guide" + i.ToString() + ".png");
		}

		#endregion

		#region Gauge

		Gauge = new CTexture[8];
		Gauge[0] = TxC(GAME + GAUGE + @$"1P.png");
		Gauge[1] = TxC(GAME + GAUGE + @$"2P.png");
		Gauge[2] = TxC(GAME + GAUGE + @$"1P_Right.png");
		Gauge[3] = TxC(GAME + GAUGE + @$"1P_4PGauge.png");
		Gauge[4] = TxC(GAME + GAUGE + @$"2P_4PGauge.png");
		Gauge[5] = TxC(GAME + GAUGE + @$"3P_4PGauge.png");
		Gauge[6] = TxC(GAME + GAUGE + @$"4P_4PGauge.png");
		Gauge[7] = TxC(GAME + GAUGE + @$"5P_4PGauge.png");

		Gauge_Base = new CTexture[8];
		Gauge_Base[0] = TxC(GAME + GAUGE + @$"1P_Base.png");
		Gauge_Base[1] = TxC(GAME + GAUGE + @$"2P_Base.png");
		Gauge_Base[2] = TxC(GAME + GAUGE + @$"1P_Base_Right.png");
		Gauge_Base[3] = TxC(GAME + GAUGE + @$"1P_Base_4PGauge.png");
		Gauge_Base[4] = TxC(GAME + GAUGE + @$"2P_Base_4PGauge.png");
		Gauge_Base[5] = TxC(GAME + GAUGE + @$"3P_Base_4PGauge.png");
		Gauge_Base[6] = TxC(GAME + GAUGE + @$"4P_Base_4PGauge.png");
		Gauge_Base[7] = TxC(GAME + GAUGE + @$"5P_Base_4PGauge.png");

		Gauge_Line = new CTexture[2];
		Gauge_Line[0] = TxC(GAME + GAUGE + @$"1P_Line.png");
		Gauge_Line[1] = TxC(GAME + GAUGE + @$"2P_Line.png");

		Gauge_Clear = new CTexture[3];
		Gauge_Clear[0] = TxC(GAME + GAUGE + @$"Clear.png");
		Gauge_Clear[1] = TxC(GAME + GAUGE + @$"Clear_2PGauge.png");
		Gauge_Clear[2] = TxC(GAME + GAUGE + @$"Clear_4PGauge.png");

		Gauge_Base_Norma = new CTexture[3];
		Gauge_Base_Norma[0] = TxC(GAME + GAUGE + @$"Norma_Base.png");
		Gauge_Base_Norma[1] = TxC(GAME + GAUGE + @$"Norma_Base_2PGauge.png");
		Gauge_Base_Norma[2] = TxC(GAME + GAUGE + @$"Norma_Base_4PGauge.png");

		Gauge_Killzone = new CTexture[3];
		Gauge_Killzone[0] = TxC(GAME + GAUGE + @$"Killzone.png");
		Gauge_Killzone[1] = TxC(GAME + GAUGE + @$"Killzone_2PGauge.png");
		Gauge_Killzone[2] = TxC(GAME + GAUGE + @$"Killzone_4PGauge.png");

		OpenTaiko.Skin.Game_Gauge_Rainbow_Ptn = OpenTaiko.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + GAUGE + @$"Rainbow{Path.DirectorySeparatorChar}"));
		if (OpenTaiko.Skin.Game_Gauge_Rainbow_Ptn != 0) {
			Gauge_Rainbow = new CTexture[OpenTaiko.Skin.Game_Gauge_Rainbow_Ptn];
			for (int i = 0; i < OpenTaiko.Skin.Game_Gauge_Rainbow_Ptn; i++) {
				Gauge_Rainbow[i] = TxC(GAME + GAUGE + @$"Rainbow{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
			}
		}

		OpenTaiko.Skin.Game_Gauge_Rainbow_Flat_Ptn = OpenTaiko.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + GAUGE + @$"Rainbow_Flat{Path.DirectorySeparatorChar}"));
		if (OpenTaiko.Skin.Game_Gauge_Rainbow_Flat_Ptn != 0) {
			Gauge_Rainbow_Flat = new CTexture[OpenTaiko.Skin.Game_Gauge_Rainbow_Flat_Ptn];
			for (int i = 0; i < OpenTaiko.Skin.Game_Gauge_Rainbow_Flat_Ptn; i++) {
				Gauge_Rainbow_Flat[i] = TxC(GAME + GAUGE + @$"Rainbow_Flat{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
			}
		}

		OpenTaiko.Skin.Game_Gauge_Rainbow_2PGauge_Ptn = OpenTaiko.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + GAUGE + @$"Rainbow_2PGauge{Path.DirectorySeparatorChar}"));
		if (OpenTaiko.Skin.Game_Gauge_Rainbow_2PGauge_Ptn != 0) {
			Gauge_Rainbow_2PGauge = new CTexture[OpenTaiko.Skin.Game_Gauge_Rainbow_2PGauge_Ptn];
			for (int i = 0; i < OpenTaiko.Skin.Game_Gauge_Rainbow_2PGauge_Ptn; i++) {
				Gauge_Rainbow_2PGauge[i] = TxC(GAME + GAUGE + @$"Rainbow_2PGauge{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
			}
		}

		// Dan

		OpenTaiko.Skin.Game_Gauge_Dan_Rainbow_Ptn = OpenTaiko.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + DANC + @$"Rainbow{Path.DirectorySeparatorChar}"));
		if (OpenTaiko.Skin.Game_Gauge_Dan_Rainbow_Ptn != 0) {
			Gauge_Dan_Rainbow = new CTexture[OpenTaiko.Skin.Game_Gauge_Dan_Rainbow_Ptn];
			for (int i = 0; i < OpenTaiko.Skin.Game_Gauge_Dan_Rainbow_Ptn; i++) {
				Gauge_Dan_Rainbow[i] = TxC(GAME + DANC + @$"Rainbow{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
			}
		}

		Gauge_Dan = new CTexture[6];

		Gauge_Dan[0] = TxC(GAME + GAUGE + @$"1P_Dan_Base.png");
		Gauge_Dan[1] = TxC(GAME + GAUGE + @$"1P_Dan.png");
		Gauge_Dan[2] = TxC(GAME + GAUGE + @$"1P_Dan_Clear_Base.png");
		Gauge_Dan[3] = TxC(GAME + GAUGE + @$"1P_Dan_Clear.png");
		Gauge_Dan[4] = TxC(GAME + GAUGE + @$"1P_Dan_Base_Right.png");
		Gauge_Dan[5] = TxC(GAME + GAUGE + @$"1P_Dan_Right.png");

		Gauge_Soul = TxC(GAME + GAUGE + @$"Soul.png");
		Gauge_Soul_Fire = TxC(GAME + GAUGE + @$"Fire.png");
		Gauge_Soul_Explosion = new CTexture[2];
		Gauge_Soul_Explosion[0] = TxC(GAME + GAUGE + @$"1P_Explosion.png");
		Gauge_Soul_Explosion[1] = TxC(GAME + GAUGE + @$"2P_Explosion.png");

		#endregion

		#region Balloon

		Balloon_Combo = new CTexture[2];
		Balloon_Combo[0] = TxC(GAME + BALLOON + @$"Combo_1P.png");
		Balloon_Combo[1] = TxC(GAME + BALLOON + @$"Combo_2P.png");
		Balloon_Roll = TxC(GAME + BALLOON + @$"Roll.png");
		Balloon_Balloon = TxC(GAME + BALLOON + @$"Balloon.png");
		Balloon_Number_Roll = TxC(GAME + BALLOON + @$"Number_Roll.png");
		Balloon_Number_Combo = TxC(GAME + BALLOON + @$"Number_Combo.png");

		Balloon_Breaking = new CTexture[6];
		for (int i = 0; i < 6; i++) {
			Balloon_Breaking[i] = TxC(GAME + BALLOON + @$"Breaking_" + i.ToString() + ".png");
		}

		Kusudama_Number = TxC(GAME + BALLOON + KUSUDAMA + @$"Kusudama_Number.png");

		Fuse_Number = TxC(GAME + BALLOON + FUSE + @$"Number_Fuse.png");
		Fuse_Balloon = TxC(GAME + BALLOON + FUSE + @$"Fuse.png");

		#endregion

		#region Effects

		Effects_Hit_Explosion = TxCAf(GAME + EFFECTS + @$"Hit{Path.DirectorySeparatorChar}Explosion.png");
		if (Effects_Hit_Explosion != null) Effects_Hit_Explosion.b加算合成 = OpenTaiko.Skin.Game_Effect_HitExplosion_AddBlend;
		Effects_Hit_Explosion_Big = TxC(GAME + EFFECTS + @$"Hit{Path.DirectorySeparatorChar}Explosion_Big.png");
		if (Effects_Hit_Explosion_Big != null) Effects_Hit_Explosion_Big.b加算合成 = OpenTaiko.Skin.Game_Effect_HitExplosionBig_AddBlend;
		Effects_Hit_FireWorks = TxC(GAME + EFFECTS + @$"Hit{Path.DirectorySeparatorChar}FireWorks.png");
		if (Effects_Hit_FireWorks != null) Effects_Hit_FireWorks.b加算合成 = OpenTaiko.Skin.Game_Effect_FireWorks_AddBlend;

		Effects_Hit_Bomb = TxCAf(GAME + EFFECTS + @$"Hit{Path.DirectorySeparatorChar}Bomb.png");


		Effects_Fire = TxC(GAME + EFFECTS + @$"Fire.png");
		if (Effects_Fire != null) Effects_Fire.b加算合成 = OpenTaiko.Skin.Game_Effect_Fire_AddBlend;

		Effects_Rainbow = TxC(GAME + EFFECTS + @$"Rainbow.png");

		Effects_GoGoSplash = TxC(GAME + EFFECTS + @$"GoGoSplash.png");
		if (Effects_GoGoSplash != null) Effects_GoGoSplash.b加算合成 = OpenTaiko.Skin.Game_Effect_GoGoSplash_AddBlend;
		Effects_Hit_Great = new CTexture[15];
		Effects_Hit_Great_Big = new CTexture[15];
		Effects_Hit_Good = new CTexture[15];
		Effects_Hit_Good_Big = new CTexture[15];
		for (int i = 0; i < 15; i++) {
			Effects_Hit_Great[i] = TxC(GAME + EFFECTS + @$"Hit{Path.DirectorySeparatorChar}" + @$"Great{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
			Effects_Hit_Great_Big[i] = TxC(GAME + EFFECTS + @$"Hit{Path.DirectorySeparatorChar}" + @$"Great_Big{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
			Effects_Hit_Good[i] = TxC(GAME + EFFECTS + @$"Hit{Path.DirectorySeparatorChar}" + @$"Good{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
			Effects_Hit_Good_Big[i] = TxC(GAME + EFFECTS + @$"Hit{Path.DirectorySeparatorChar}" + @$"Good_Big{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
		}
		OpenTaiko.Skin.Game_Effect_Roll_Ptn = OpenTaiko.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + EFFECTS + @$"Roll{Path.DirectorySeparatorChar}"));
		Effects_Roll = new CTexture[OpenTaiko.Skin.Game_Effect_Roll_Ptn];
		for (int i = 0; i < OpenTaiko.Skin.Game_Effect_Roll_Ptn; i++) {
			Effects_Roll[i] = TxC(GAME + EFFECTS + @$"Roll{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
		}

		#endregion

		#region Lane

		Lane_Base = new CTexture[3];
		Lane_Text = new CTexture[3];
		string[] Lanes = new string[3] { "Normal", "Expert", "Master" };
		for (int i = 0; i < 3; i++) {
			Lane_Base[i] = TxC(GAME + LANE + "Base_" + Lanes[i] + ".png");
			Lane_Text[i] = TxC(GAME + LANE + "Text_" + Lanes[i] + ".png");
		}

		Lane_Red = new CTexture[2];
		Lane_Blue = new CTexture[2];
		Lane_Clap = new CTexture[2];

		var _suffixes = new string[] { "", "_Konga" };

		for (int i = 0; i < Lane_Red.Length; i++) {
			Lane_Red[i] = TxC(GAME + LANE + @$"Red" + _suffixes[i] + @$".png");
			Lane_Blue[i] = TxC(GAME + LANE + @$"Blue" + _suffixes[i] + @$".png");
			Lane_Clap[i] = TxC(GAME + LANE + @$"Clap" + _suffixes[i] + @$".png");
		}


		Lane_Yellow = TxC(GAME + LANE + @$"Yellow.png");
		Lane_Background_Main = TxC(GAME + LANE + @$"Background_Main.png");
		Lane_Background_AI = TxC(GAME + LANE + @$"Background_AI.png");
		Lane_Background_Sub = TxC(GAME + LANE + @$"Background_Sub.png");
		Lane_Background_GoGo = TxC(GAME + LANE + @$"Background_GoGo.png");

		#endregion

		#region GameMode

		GameMode_Timer_Tick = TxC(GAME + GAMEMODE + @$"Timer_Tick.png");
		GameMode_Timer_Frame = TxC(GAME + GAMEMODE + @$"Timer_Frame.png");

		#endregion

		#region DanC

		DanC_Background = TxC(GAME + DANC + @$"Background.png");
		DanC_Gauge = new CTexture[4];
		var type = new string[] { "Normal", "Reach", "Clear", "Flush" };
		for (int i = 0; i < 4; i++) {
			DanC_Gauge[i] = TxC(GAME + DANC + @$"Gauge_" + type[i] + ".png");
		}
		DanC_Base = TxC(GAME + DANC + @$"Base.png");
		DanC_Base_Small = TxC(GAME + DANC + @$"Base_Small.png");

		DanC_Gauge_Base = TxC(GAME + DANC + @$"Gauge_Base.png");
		DanC_Failed = TxC(GAME + DANC + @$"Failed.png");
		DanC_Number = TxC(GAME + DANC + @$"Number.png");
		DanC_Small_Number = TxC(GAME + DANC + @$"Small_Number.png");
		DanC_ExamType = TxC(GAME + DANC + @$"ExamType.png");
		DanC_ExamRange = TxC(GAME + DANC + @$"ExamRange.png");
		DanC_ExamUnit = TxC(GAME + DANC + @$"ExamUnit.png");
		DanC_Screen = TxC(GAME + DANC + @$"Screen.png");
		DanC_SmallBase = TxC(GAME + DANC + @$"SmallBase.png");
		DanC_Small_ExamCymbol = TxC(GAME + DANC + @$"Small_ExamCymbol.png");
		DanC_ExamCymbol = TxC(GAME + DANC + @$"ExamCymbol.png");
		DanC_MiniNumber = TxC(GAME + DANC + @$"MiniNumber.png");

		#endregion

		#region PuchiChara

		var puchicharaDirs = System.IO.Directory.GetDirectories(OpenTaiko.strEXEのあるフォルダ + GLOBAL + PUCHICHARA);
		OpenTaiko.Skin.Puchichara_Ptn = puchicharaDirs.Length;

		Puchichara = new CPuchichara[OpenTaiko.Skin.Puchichara_Ptn];
		OpenTaiko.Skin.Puchicharas_Name = new string[OpenTaiko.Skin.Puchichara_Ptn];

		for (int i = 0; i < OpenTaiko.Skin.Puchichara_Ptn; i++) {
			Puchichara[i] = new CPuchichara(puchicharaDirs[i]);

			OpenTaiko.Skin.Puchicharas_Name[i] = System.IO.Path.GetFileName(puchicharaDirs[i]);
		}

		///TJAPlayer3.Skin.Puchichara_Ptn = 5 * Math.Max(1, (PuchiChara.szテクスチャサイズ.Height / 256));


		#endregion

		#region Training

		Tokkun_DownBG = TxC(GAME + TRAINING + @$"Down.png");
		Tokkun_BigTaiko = TxC(GAME + TRAINING + @$"BigTaiko.png");
		Tokkun_ProgressBar = TxC(GAME + TRAINING + @$"ProgressBar_Red.png");
		Tokkun_ProgressBarWhite = TxC(GAME + TRAINING + @$"ProgressBar_White.png");
		Tokkun_GoGoPoint = TxC(GAME + TRAINING + @$"GoGoPoint.png");
		Tokkun_JumpPoint = TxC(GAME + TRAINING + @$"JumpPoint.png");
		Tokkun_Background_Up = TxC(GAME + TRAINING + @$"Background_Up.png");
		Tokkun_BigNumber = TxC(GAME + TRAINING + @$"BigNumber.png");
		Tokkun_SmallNumber = TxC(GAME + TRAINING + @$"SmallNumber.png");
		Tokkun_Speed_Measure = TxC(GAME + TRAINING + @$"Speed_Measure.png");

		#endregion

		#region [20_Tower]

		Tower_Miss = TxC(GAME + TOWER + @$"Miss.png");

		// Tower elements
		string[] towerDirectories = System.IO.Directory.GetDirectories(CSkin.Path(BASE + GAME + TOWER + TOWERFLOOR));
		OpenTaiko.Skin.Game_Tower_Ptn = towerDirectories.Length;
		OpenTaiko.Skin.Game_Tower_Names = new string[OpenTaiko.Skin.Game_Tower_Ptn];
		for (int i = 0; i < OpenTaiko.Skin.Game_Tower_Ptn; i++)
			OpenTaiko.Skin.Game_Tower_Names[i] = new DirectoryInfo(towerDirectories[i]).Name;
		Tower_Top = new CTexture[OpenTaiko.Skin.Game_Tower_Ptn];
		Tower_Base = new CTexture[OpenTaiko.Skin.Game_Tower_Ptn][];
		Tower_Deco = new CTexture[OpenTaiko.Skin.Game_Tower_Ptn][];

		OpenTaiko.Skin.Game_Tower_Ptn_Base = new int[OpenTaiko.Skin.Game_Tower_Ptn];
		OpenTaiko.Skin.Game_Tower_Ptn_Deco = new int[OpenTaiko.Skin.Game_Tower_Ptn];

		for (int i = 0; i < OpenTaiko.Skin.Game_Tower_Ptn; i++) {
			OpenTaiko.Skin.Game_Tower_Ptn_Base[i] = OpenTaiko.t連番画像の枚数を数える((towerDirectories[i] + @$"{Path.DirectorySeparatorChar}Base{Path.DirectorySeparatorChar}"), "Base");
			OpenTaiko.Skin.Game_Tower_Ptn_Deco[i] = OpenTaiko.t連番画像の枚数を数える((towerDirectories[i] + @$"{Path.DirectorySeparatorChar}Deco{Path.DirectorySeparatorChar}"), "Deco");

			Tower_Top[i] = TxC(GAME + TOWER + TOWERFLOOR + OpenTaiko.Skin.Game_Tower_Names[i] + @$"{Path.DirectorySeparatorChar}Top.png");

			Tower_Base[i] = new CTexture[OpenTaiko.Skin.Game_Tower_Ptn_Base[i]];
			Tower_Deco[i] = new CTexture[OpenTaiko.Skin.Game_Tower_Ptn_Deco[i]];

			for (int j = 0; j < OpenTaiko.Skin.Game_Tower_Ptn_Base[i]; j++) {
				Tower_Base[i][j] = TxC(GAME + TOWER + TOWERFLOOR + OpenTaiko.Skin.Game_Tower_Names[i] + @$"{Path.DirectorySeparatorChar}Base{Path.DirectorySeparatorChar}Base" + j.ToString() + ".png");
			}

			for (int j = 0; j < OpenTaiko.Skin.Game_Tower_Ptn_Deco[i]; j++) {
				Tower_Deco[i][j] = TxC(GAME + TOWER + TOWERFLOOR + OpenTaiko.Skin.Game_Tower_Names[i] + @$"{Path.DirectorySeparatorChar}Deco{Path.DirectorySeparatorChar}Deco" + j.ToString() + ".png");
			}
		}



		#endregion

		#region [21_ModIcons]

		HiSp = new CTexture[14];
		for (int i = 0; i < HiSp.Length; i++) {
			HiSp[i] = TxC(GAME + MODICONS + @$"HS{Path.DirectorySeparatorChar}" + i.ToString() + @$".png");
		}

		Mod_Timing = new CTexture[5];
		for (int i = 0; i < Mod_Timing.Length; i++) {
			Mod_Timing[i] = TxC(GAME + MODICONS + @$"Timing{Path.DirectorySeparatorChar}" + i.ToString() + @$".png");
		}

		Mod_SongSpeed = new CTexture[2];
		for (int i = 0; i < Mod_SongSpeed.Length; i++) {
			Mod_SongSpeed[i] = TxC(GAME + MODICONS + @$"SongSpeed{Path.DirectorySeparatorChar}" + i.ToString() + @$".png");
		}

		Mod_Fun = new CTexture[3];
		for (int i = 0; i < Mod_Fun.Length; i++) {
			Mod_Fun[i] = TxC(GAME + MODICONS + @$"Fun{Path.DirectorySeparatorChar}" + i.ToString() + @$".png");
		}

		Mod_Doron = TxC(GAME + MODICONS + @$"Doron.png");
		Mod_Stealth = TxC(GAME + MODICONS + @$"Stealth.png");
		Mod_Mirror = TxC(GAME + MODICONS + @$"Mirror.png");
		Mod_Super = TxC(GAME + MODICONS + @$"Super.png");
		Mod_Hyper = TxC(GAME + MODICONS + @$"Hyper.png");
		Mod_Random = TxC(GAME + MODICONS + @$"Random.png");
		Mod_Auto = TxC(GAME + MODICONS + @$"Auto.png");
		Mod_Just = TxC(GAME + MODICONS + @$"Just.png");
		Mod_Safe = TxC(GAME + MODICONS + @$"Safe.png");
		Mod_None = TxC(GAME + MODICONS + @$"None.png");

		#endregion

		#region [22_AIBattle]

		AIBattle_SectionTime_Panel = TxC(GAME + AIBATTLE + @$"SectionTime_Panel.png");

		AIBattle_SectionTime_Bar_Base = TxC(GAME + AIBATTLE + @$"SectionTime_Bar_Base.png");
		AIBattle_SectionTime_Bar_Finish = TxC(GAME + AIBATTLE + @$"SectionTime_Bar_Finish.png");
		AIBattle_SectionTime_Bar_Normal = TxC(GAME + AIBATTLE + @$"SectionTime_Bar_Normal.png");

		AIBattle_Batch_Base = TxC(GAME + AIBATTLE + @$"Batch_Base.png");
		AIBattle_Batch = TxC(GAME + AIBATTLE + @$"Batch.png");

		AIBattle_Judge_Meter[0] = TxC(GAME + AIBATTLE + @$"Judge_Meter.png");
		AIBattle_Judge_Meter[1] = TxC(GAME + AIBATTLE + @$"Judge_Meter_AI.png");

		AIBattle_Judge_Number = TxC(GAME + AIBATTLE + @$"Judge_Number.png");

		#endregion

		#endregion

		#region 6_結果発表

		Result_Gauge[0] = TxC(RESULT + @$"Gauge.png");
		Result_Gauge_Base[0] = TxC(RESULT + @$"Gauge_Base.png");
		Result_Gauge[1] = TxC(RESULT + @$"Gauge_2.png");
		Result_Gauge_Base[1] = TxC(RESULT + @$"Gauge_Base_2.png");
		Result_Gauge[2] = TxC(RESULT + @$"Gauge_3.png");
		Result_Gauge_Base[2] = TxC(RESULT + @$"Gauge_Base_3.png");
		Result_Gauge[3] = TxC(RESULT + @$"Gauge_4.png");
		Result_Gauge_Base[3] = TxC(RESULT + @$"Gauge_Base_4.png");
		Result_Gauge[4] = TxC(RESULT + @$"Gauge_5.png");
		Result_Gauge_Base[4] = TxC(RESULT + @$"Gauge_Base_5.png");

		Result_Gauge_Frame = TxC(RESULT + @$"Gauge_Frame.png");
		Result_Gauge_Clear = TxC(RESULT + @$"Gauge_Clear.png");
		Result_Gauge_Clear_Base = TxC(RESULT + @$"Gauge_Clear_Base.png");
		Result_Gauge_Killzone = TxC(RESULT + @$"Gauge_Killzone.png");

		Result_Header = TxC(RESULT + @$"Header.png");
		Result_Number = TxC(RESULT + @$"Number.png");
		Result_Panel = TxC(RESULT + @$"Panel.png");
		Result_Panel_2P = TxC(RESULT + @$"Panel_2.png");
		Result_Soul_Text = TxC(RESULT + @$"Soul_Text.png");
		Result_Soul_Fire = TxC(RESULT + @$"Result_Soul_Fire.png");
		Result_Diff_Bar = TxC(RESULT + @$"DifficultyBar.png");
		Result_Score_Number = TxC(RESULT + @$"Score_Number.png");
		Result_Dan = TxC(RESULT + @$"Dan.png");

		Result_CrownEffect = TxC(RESULT + @$"CrownEffect.png");
		Result_ScoreRankEffect = TxC(RESULT + @$"ScoreRankEffect.png");
		//Result_Cloud = TxC(RESULT + @$"Cloud.png");
		Result_Shine = TxC(RESULT + @$"Shine.png");

		Result_Speech_Bubble[0] = TxC(RESULT + @$"Speech_Bubble.png");
		Result_Speech_Bubble[1] = TxC(RESULT + @$"Speech_Bubble_2.png");

		Result_Speech_Bubble_V2[0] = TxC(RESULT + @$"Speech_Bubble_V2_Left.png");
		Result_Speech_Bubble_V2[1] = TxC(RESULT + @$"Speech_Bubble_V2_Right.png");
		Result_Speech_Bubble_V2[2] = TxC(RESULT + @$"Speech_Bubble_V2_4P_5P.png");

		Result_Flower = TxC(RESULT + @$"Flower{Path.DirectorySeparatorChar}Flower.png");

		for (int i = 0; i < 4; i++)
			Result_Panel_4P[i] = TxC(RESULT + @$"Panel_4P_" + (i + 1).ToString() + ".png");

		for (int i = 0; i < 5; i++)
			Result_Panel_5P[i] = TxC(RESULT + @$"Panel_5P_" + (i + 1).ToString() + ".png");

		for (int i = 1; i <= 5; i++)
			Result_Flower_Rotate[i - 1] = TxC(RESULT + @$"Flower{Path.DirectorySeparatorChar}Rotate_" + i.ToString() + ".png");

		//for (int i = 0; i < 3; i++)
		//Result_Work[i] = TxC(RESULT + @$"Work{Path.DirectorySeparatorChar}" + i.ToString() + ".png");

		OpenTaiko.Skin.Result_Gauge_Rainbow_Ptn = OpenTaiko.t連番画像の枚数を数える(CSkin.Path(BASE + RESULT + @$"Rainbow{Path.DirectorySeparatorChar}"));
		if (OpenTaiko.Skin.Result_Gauge_Rainbow_Ptn != 0) {
			Result_Rainbow = new CTexture[OpenTaiko.Skin.Result_Gauge_Rainbow_Ptn];
			for (int i = 0; i < OpenTaiko.Skin.Result_Gauge_Rainbow_Ptn; i++) {
				Result_Rainbow[i] = TxC(RESULT + @$"Rainbow{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
			}
		}

		//for (int i = 0; i < 6; i++)
		//Result_Background[i] = TxC(RESULT + @$"Background_" + i.ToString() + ".png");

		//for (int i = 0; i < 4; i++)
		//Result_Mountain[i] = TxC(RESULT + @$"Background_Mountain_" + i.ToString() + ".png");

		for (int i = 0; i < 3; i++)
			Result_Crown[i] = TxC(RESULT + @$"Crown{Path.DirectorySeparatorChar}Crown_" + i.ToString() + ".png");

		#endregion

		#region 7_AIResults

		Result_AIBattle_Panel_AI = TxC(RESULT + @$"AIBattle{Path.DirectorySeparatorChar}Panel_AI.png");
		Result_AIBattle_Batch = TxC(RESULT + @$"AIBattle{Path.DirectorySeparatorChar}Batch.png");
		Result_AIBattle_SectionPlate = TxC(RESULT + @$"AIBattle{Path.DirectorySeparatorChar}SectionPlate.png");
		Result_AIBattle_WinFlag_Clear = TxC(RESULT + @$"AIBattle{Path.DirectorySeparatorChar}WinFlag_Win.png");
		Result_AIBattle_WinFlag_Lose = TxC(RESULT + @$"AIBattle{Path.DirectorySeparatorChar}WinFlag_Lose.png");

		#endregion

		#region [7_DanResults]

		//DanResult_Background = TxC(DANRESULT + @$"Background.png");
		DanResult_Rank = TxC(DANRESULT + @$"Rank.png");
		DanResult_SongPanel_Base = TxC(DANRESULT + @$"SongPanel_Base.png");
		DanResult_StatePanel_Base = TxC(DANRESULT + @$"StatePanel_Base.png");
		DanResult_SongPanel_Main = TxC(DANRESULT + @$"SongPanel_Main.png");
		DanResult_StatePanel_Main = TxC(DANRESULT + @$"StatePanel_Main.png");

		#endregion

		#region [8_TowerResults]

		OpenTaiko.Skin.Game_Tower_Ptn_Result = OpenTaiko.t連番画像の枚数を数える(CSkin.Path(BASE + TOWERRESULT + @$"Tower{Path.DirectorySeparatorChar}"));
		TowerResult_Tower = new CTexture[OpenTaiko.Skin.Game_Tower_Ptn_Result];

		TowerResult_Background = TxC(TOWERRESULT + @$"Background.png");
		TowerResult_Panel = TxC(TOWERRESULT + @$"Panel.png");

		TowerResult_ScoreRankEffect = TxC(TOWERRESULT + @$"ScoreRankEffect.png");

		for (int i = 0; i < OpenTaiko.Skin.Game_Tower_Ptn_Result; i++) {
			TowerResult_Tower[i] = TxC(TOWERRESULT + @$"Tower{Path.DirectorySeparatorChar}" + i.ToString() + ".png");
		}

		#endregion

		#region [10_Heya]

		//Heya_Background = TxC(HEYA + @$"Background.png");
		Heya_Center_Menu_Bar = TxC(HEYA + @$"Center_Menu_Bar.png");
		Heya_Center_Menu_Box = TxC(HEYA + @$"Center_Menu_Box.png");
		Heya_Center_Menu_Box_Slot = TxC(HEYA + @$"Center_Menu_Box_Slot.png");
		Heya_Side_Menu = TxC(HEYA + @$"Side_Menu.png");
		Heya_Render_Field = TxC(HEYA + @$"Render_Field.png");
		Heya_Center_Menu_Background = TxC(HEYA + @$"Center_Menu_Background.png");
		Heya_Description_Panel = TxC(HEYA + @$"Description_Panel.png");
		Heya_Box = TxC(HEYA + @$"Box.png");
		Heya_Lock = TxC(HEYA + @$"Lock.png");

		#endregion

		#region [11_Characters]

		#region [Character count initialisations]

		var charaDirs = System.IO.Directory.GetDirectories(OpenTaiko.strEXEのあるフォルダ + GLOBAL + CHARACTERS);
		OpenTaiko.Skin.Characters_Ptn = charaDirs.Length;

		Characters_Heya_Preview = new CTexture[OpenTaiko.Skin.Characters_Ptn];
		Characters_Heya_Render = new CTexture[OpenTaiko.Skin.Characters_Ptn];
		Characters_Result_Clear_1P = new CTexture[OpenTaiko.Skin.Characters_Ptn];
		Characters_Result_Failed_1P = new CTexture[OpenTaiko.Skin.Characters_Ptn];
		Characters_Result_Clear_2P = new CTexture[OpenTaiko.Skin.Characters_Ptn];
		Characters_Result_Failed_2P = new CTexture[OpenTaiko.Skin.Characters_Ptn];
		Characters = new CCharacter[OpenTaiko.Skin.Characters_Ptn];

		Characters_Normal = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Normal_Missed = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Normal_MissedDown = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Normal_Cleared = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Normal_Maxed = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_MissIn = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_MissDownIn = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_GoGoTime = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_GoGoTime_Maxed = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_10Combo = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_10Combo_Clear = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_10Combo_Maxed = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_GoGoStart = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_GoGoStart_Clear = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_GoGoStart_Maxed = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Become_Cleared = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Become_Maxed = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_SoulOut = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_ClearOut = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Return = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Balloon_Breaking = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Balloon_Broke = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Balloon_Miss = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Kusudama_Idle = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Kusudama_Breaking = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Kusudama_Broke = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Kusudama_Miss = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Title_Entry = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Title_Normal = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Result_Clear = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Result_Failed = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Result_Failed_In = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Result_Normal = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Menu_Loop = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Menu_Start = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Menu_Select = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Menu_Wait = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Standing = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Climbing = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Running = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Clear = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Fail = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Standing_Tired = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Climbing_Tired = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Running_Tired = new CTexture[OpenTaiko.Skin.Characters_Ptn][];
		Characters_Tower_Clear_Tired = new CTexture[OpenTaiko.Skin.Characters_Ptn][];

		OpenTaiko.Skin.Characters_DirName = new string[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Normal_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Normal_Missed_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Normal_MissedDown_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Normal_Cleared_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Normal_Maxed_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_MissIn_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_MissDownIn_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_GoGoTime_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_GoGoTime_Maxed_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_10Combo_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_10Combo_Clear_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_10Combo_Maxed_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_GoGoStart_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_GoGoStart_Clear_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_GoGoStart_Maxed_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Become_Cleared_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Become_Maxed_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_SoulOut_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_ClearOut_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Return_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Balloon_Breaking_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Balloon_Broke_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Balloon_Miss_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Kusudama_Idle_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Kusudama_Breaking_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Kusudama_Broke_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Kusudama_Miss_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Title_Entry_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Title_Normal_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Result_Clear_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Result_Failed_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Result_Failed_In_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Result_Normal_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Loop_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Start_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Select_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Wait_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Standing_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Climbing_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Running_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Clear_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Fail_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Standing_Tired_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Climbing_Tired_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Running_Tired_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Clear_Tired_Ptn = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Clear_IsLooping = new bool[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Clear_Tired_IsLooping = new bool[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Tower_Fail_IsLooping = new bool[OpenTaiko.Skin.Characters_Ptn];

		OpenTaiko.Skin.Characters_Resolution = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Heya_Render_Offset = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_UseResult1P = new bool[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Offset = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Result_Offset = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_X = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Y = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_4P = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_5P = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_X_AI = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Y_AI = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Balloon_X = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Balloon_Y = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Balloon_4P = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Balloon_5P = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Kusudama_X = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Kusudama_Y = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_Normal = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_10Combo = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_10Combo_Clear = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_10ComboMax = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_Miss = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_MissDown = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_ClearIn = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_Clear = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_ClearMax = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_MissIn = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_MissDownIn = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_GoGoStart = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_GoGoStart_Clear = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_GoGoStartMax = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_GoGo = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_GoGoMax = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_SoulIn = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_SoulOut = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_ClearOut = new int[OpenTaiko.Skin.Characters_Ptn][];
		OpenTaiko.Skin.Characters_Motion_Return = new int[OpenTaiko.Skin.Characters_Ptn][];
		/*
        TJAPlayer3.Skin.Characters_Motion_Tower_Standing = new int[TJAPlayer3.Skin.Characters_Ptn][];
        TJAPlayer3.Skin.Characters_Motion_Tower_Climbing = new int[TJAPlayer3.Skin.Characters_Ptn][];
        TJAPlayer3.Skin.Characters_Motion_Tower_Running = new int[TJAPlayer3.Skin.Characters_Ptn][];
        TJAPlayer3.Skin.Characters_Motion_Tower_Clear = new int[TJAPlayer3.Skin.Characters_Ptn][];
        TJAPlayer3.Skin.Characters_Motion_Tower_Fail = new int[TJAPlayer3.Skin.Characters_Ptn][];
        TJAPlayer3.Skin.Characters_Motion_Tower_Standing_Tired = new int[TJAPlayer3.Skin.Characters_Ptn][];
        TJAPlayer3.Skin.Characters_Motion_Tower_Climbing_Tired = new int[TJAPlayer3.Skin.Characters_Ptn][];
        TJAPlayer3.Skin.Characters_Motion_Tower_Running_Tired = new int[TJAPlayer3.Skin.Characters_Ptn][];
        TJAPlayer3.Skin.Characters_Motion_Tower_Clear_Tired = new int[TJAPlayer3.Skin.Characters_Ptn][];
        */
		OpenTaiko.Skin.Characters_Beat_Normal = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_Miss = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_MissDown = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_Clear = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_GoGo = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_10Combo = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_10Combo_Clear = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_10ComboMax = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_ClearIn = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_ClearMax = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_MissIn = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_MissDownIn = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_GoGoStart = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_GoGoStart_Clear = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_GoGoStartMax = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_GoGoMax = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_SoulIn = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_SoulOut = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_ClearOut = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_Return = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_Tower_Standing = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_Tower_Clear = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_Tower_Fail = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_Tower_Standing_Tired = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Beat_Tower_Clear_Tired = new float[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Balloon_Timer = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Balloon_Delay = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Balloon_FadeOut = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Title_Entry_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Title_Normal_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Loop_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Select_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Start_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Menu_Wait_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Result_Normal_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Result_Clear_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Result_Failed_In_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];
		OpenTaiko.Skin.Characters_Result_Failed_AnimationDuration = new int[OpenTaiko.Skin.Characters_Ptn];

		for (int i = 0; i < charaDirs.Length; i++) {
			OpenTaiko.Skin.Characters_DirName[i] = System.IO.Path.GetFileName(charaDirs[i]);
		}

		#endregion

		for (int i = 0; i < 5; i++) {
			OpenTaiko.SaveFileInstances[i].tReindexCharacter(OpenTaiko.Skin.Characters_DirName);
			this.ReloadCharacter(-1, OpenTaiko.SaveFileInstances[i].data.Character, i, true);
		}


		for (int i = 0; i < OpenTaiko.Skin.Characters_Ptn; i++) {
			Characters_Heya_Preview[i] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Normal{Path.DirectorySeparatorChar}0.png");
			Characters_Heya_Render[i] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Render.png");
			Characters_Result_Clear_1P[i] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Result_Clear_1P.png");
			Characters_Result_Failed_1P[i] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Result_Failed_1P.png");
			Characters_Result_Clear_2P[i] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Result_Clear_2P.png");
			Characters_Result_Failed_2P[i] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Result_Failed_2P.png");

			OpenTaiko.Skin.Characters_Resolution[i] = new int[] { 1280, 720 };
			OpenTaiko.Skin.Characters_Heya_Render_Offset[i] = new int[] { 0, 0 };
			OpenTaiko.Skin.Characters_UseResult1P[i] = false;


			var _str = "";
			OpenTaiko.Skin.LoadSkinConfigFromFile(charaDirs[i] + @$"{Path.DirectorySeparatorChar}CharaConfig.txt", ref _str);

			string[] delimiter = { "\n", "\r" };
			string[] strSingleLine = _str.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

			foreach (string line in strSingleLine) {
				if (line.StartsWith("Chara_Resolution=")) // required for Heya resolution compatibility
				{
					string[] values = line.Substring(17).Trim().Split(',');
					OpenTaiko.Skin.Characters_Resolution[i][0] = int.Parse(values[0]);
					OpenTaiko.Skin.Characters_Resolution[i][1] = int.Parse(values[1]);
				} else if (line.StartsWith("Heya_Chara_Render_Offset=")) {
					string[] values = line.Substring(25).Trim().Split(',');
					OpenTaiko.Skin.Characters_Heya_Render_Offset[i][0] = int.Parse(values[0]);
					OpenTaiko.Skin.Characters_Heya_Render_Offset[i][1] = int.Parse(values[1]);
				} else if (line.StartsWith("Result_UseResult1P=")) {
					OpenTaiko.Skin.Characters_UseResult1P[i] = FDK.CConversion.bONorOFF(line.Substring(19).Trim()[0]);
				}
			}

			Characters[i] = new CCharacter(charaDirs[i], i);
		}


		#endregion

		#region [12_OnlineLounge]

		//OnlineLounge_Background = TxC(ONLINELOUNGE + @"Background.png");
		OnlineLounge_Box = TxC(ONLINELOUNGE + @"Box.png");
		OnlineLounge_Center_Menu_Bar = TxC(ONLINELOUNGE + @"Center_Menu_Bar.png");
		OnlineLounge_Center_Menu_Box_Slot = TxC(ONLINELOUNGE + @"Center_Menu_Box_Slot.png");
		OnlineLounge_Side_Menu = TxC(ONLINELOUNGE + @"Side_Menu.png");
		OnlineLounge_Context = TxC(ONLINELOUNGE + @"Context.png");
		OnlineLounge_Song_Box = TxC(ONLINELOUNGE + @"Song_Box.png");
		OnlineLounge_Return_Box = TxC(ONLINELOUNGE + @"Return_Box.png");

		#endregion

		#region [13_TowerSelect]

		TowerSelect_Tower = TxC(TOWERSELECT + @"Tower.png");

		#endregion

		if (OpenTaiko.ConfigIni.PreAssetsLoading) {
			foreach (var act in OpenTaiko.app.listTopLevelActivities) {
				act.CreateManagedResource();
				act.CreateUnmanagedResource();
			}
		}
	}

	public int[] CreateNumberedArrayFromInt(int total) {
		int[] array = new int[total];
		for (int i = 0; i < total; i++) {
			array[i] = i;
		}
		return array;
	}

	public CSkin.CSystemSound VoiceSelectOggOrWav(string basePath) {
		if (File.Exists(basePath + @$".ogg"))
			return new CSkin.CSystemSound(basePath + @$".ogg", false, false, true, ESoundGroup.Voice);
		else
			return new CSkin.CSystemSound(basePath + @$".wav", false, false, true, ESoundGroup.Voice);
	}

	public void ReloadCharacter(int old, int newC, int player, bool primary = false) {
		if (old == newC)
			return;

		if (old >= 0 &&
			(OpenTaiko.SaveFileInstances[0].data.Character != old || player == 0) &&
			(OpenTaiko.SaveFileInstances[1].data.Character != old || player == 1) &&
			(OpenTaiko.SaveFileInstances[2].data.Character != old || player == 2) &&
			(OpenTaiko.SaveFileInstances[3].data.Character != old || player == 3) &&
			(OpenTaiko.SaveFileInstances[4].data.Character != old || player == 4)) {
			int i = old;

			#region [Dispose the previous character]

			for (int j = 0; j < OpenTaiko.Skin.Characters_Menu_Loop_Ptn[i]; j++)
				Characters_Menu_Loop[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Menu_Start_Ptn[i]; j++)
				Characters_Menu_Start[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Menu_Select_Ptn[i]; j++)
				Characters_Menu_Select[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Menu_Wait_Ptn[i]; j++)
				Characters_Menu_Wait[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Result_Normal_Ptn[i]; j++)
				Characters_Result_Normal[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Result_Failed_In_Ptn[i]; j++)
				Characters_Result_Failed_In[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Result_Failed_Ptn[i]; j++)
				Characters_Result_Failed[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Result_Clear_Ptn[i]; j++)
				Characters_Result_Clear[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Title_Normal_Ptn[i]; j++)
				Characters_Title_Normal[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Title_Entry_Ptn[i]; j++)
				Characters_Title_Entry[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_Ptn[i]; j++)
				Characters_Normal[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_Missed_Ptn[i]; j++)
				Characters_Normal_Missed[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_MissedDown_Ptn[i]; j++)
				Characters_Normal_MissedDown[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_Cleared_Ptn[i]; j++)
				Characters_Normal_Cleared[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_Maxed_Ptn[i]; j++)
				Characters_Normal_Maxed[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_MissIn_Ptn[i]; j++)
				Characters_MissIn[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_MissDownIn_Ptn[i]; j++)
				Characters_MissDownIn[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoTime_Ptn[i]; j++)
				Characters_GoGoTime[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoTime_Maxed_Ptn[i]; j++)
				Characters_GoGoTime_Maxed[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoStart_Ptn[i]; j++)
				Characters_GoGoStart[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoStart_Clear_Ptn[i]; j++)
				Characters_GoGoStart_Clear[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoStart_Maxed_Ptn[i]; j++)
				Characters_GoGoStart_Maxed[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_10Combo_Ptn[i]; j++)
				Characters_10Combo[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_10Combo_Clear_Ptn[i]; j++)
				Characters_10Combo_Clear[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_10Combo_Maxed_Ptn[i]; j++)
				Characters_10Combo_Maxed[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Become_Cleared_Ptn[i]; j++)
				Characters_Become_Cleared[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Become_Maxed_Ptn[i]; j++)
				Characters_Become_Maxed[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_SoulOut_Ptn[i]; j++)
				Characters_SoulOut[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_ClearOut_Ptn[i]; j++)
				Characters_ClearOut[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Return_Ptn[i]; j++)
				Characters_Return[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Balloon_Breaking_Ptn[i]; j++)
				Characters_Balloon_Breaking[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Balloon_Broke_Ptn[i]; j++)
				Characters_Balloon_Broke[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Balloon_Miss_Ptn[i]; j++)
				Characters_Balloon_Miss[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Kusudama_Idle_Ptn[i]; j++)
				Characters_Kusudama_Idle[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Kusudama_Breaking_Ptn[i]; j++)
				Characters_Kusudama_Breaking[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Kusudama_Broke_Ptn[i]; j++)
				Characters_Kusudama_Broke[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Kusudama_Miss_Ptn[i]; j++)
				Characters_Kusudama_Miss[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Standing_Ptn[i]; j++)
				Characters_Tower_Standing[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Climbing_Ptn[i]; j++)
				Characters_Tower_Climbing[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Running_Ptn[i]; j++)
				Characters_Tower_Running[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Clear_Ptn[i]; j++)
				Characters_Tower_Clear[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Fail_Ptn[i]; j++)
				Characters_Tower_Fail[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Standing_Tired_Ptn[i]; j++)
				Characters_Tower_Standing_Tired[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Climbing_Tired_Ptn[i]; j++)
				Characters_Tower_Climbing_Tired[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Running_Tired_Ptn[i]; j++)
				Characters_Tower_Running_Tired[i][j]?.Dispose();

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Clear_Tired_Ptn[i]; j++)
				Characters_Tower_Clear_Tired[i][j]?.Dispose();
			#endregion
		}

		string charaPath = OpenTaiko.strEXEのあるフォルダ + GLOBAL + CHARACTERS + OpenTaiko.Skin.Characters_DirName[newC];

		if ((newC >= 0 &&
			 OpenTaiko.SaveFileInstances[0].data.Character != newC &&
			 OpenTaiko.SaveFileInstances[1].data.Character != newC &&
			 OpenTaiko.SaveFileInstances[2].data.Character != newC &&
			 OpenTaiko.SaveFileInstances[3].data.Character != newC &&
			 OpenTaiko.SaveFileInstances[4].data.Character != newC) || primary) {
			int i = newC;

			#region [Allocate the new character]

			#region [Character individual values count initialisation]

			OpenTaiko.Skin.Characters_Normal_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Normal{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Normal_Missed_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Miss{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Normal_MissedDown_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}MissDown{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_MissIn_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}MissIn{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_MissDownIn_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}MissDownIn{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Normal_Cleared_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Normal_Maxed_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Clear_Max{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_GoGoTime_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}GoGo{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_GoGoTime_Maxed_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}GoGo_Max{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_10Combo_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}10combo{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_10Combo_Clear_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}10combo_Clear{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_10Combo_Maxed_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}10combo_Max{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_GoGoStart_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}GoGoStart{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_GoGoStart_Clear_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}GoGoStart_Clear{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_GoGoStart_Maxed_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}GoGoStart_Max{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Become_Cleared_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Clearin{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Become_Maxed_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Soulin{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_SoulOut_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}SoulOut{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_ClearOut_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}ClearOut{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Return_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Return{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Balloon_Breaking_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Balloon_Breaking{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Balloon_Broke_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Balloon_Broke{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Balloon_Miss_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Balloon_Miss{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Kusudama_Idle_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Kusudama_Idle{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Kusudama_Breaking_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Kusudama_Breaking{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Kusudama_Broke_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Kusudama_Broke{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Kusudama_Miss_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Kusudama_Miss{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Title_Entry_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Title_Entry{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Title_Normal_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Title_Normal{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Menu_Loop_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Menu_Loop{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Menu_Select_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Menu_Select{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Menu_Start_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Menu_Start{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Menu_Wait_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Menu_Wait{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Result_Clear_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Result_Clear{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Result_Failed_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Result_Failed{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Result_Failed_In_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Result_Failed_In{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Result_Normal_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Result_Normal{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Standing_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Standing{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Climbing_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Climbing{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Running_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Running{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Clear_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Fail_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Fail{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Standing_Tired_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Standing_Tired{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Climbing_Tired_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Climbing_Tired{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Running_Tired_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Running_Tired{Path.DirectorySeparatorChar}");
			OpenTaiko.Skin.Characters_Tower_Clear_Tired_Ptn[i] = OpenTaiko.t連番画像の枚数を数える(charaPath + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Clear_Tired{Path.DirectorySeparatorChar}");

			Characters_Normal[i] = new CTexture[OpenTaiko.Skin.Characters_Normal_Ptn[i]];
			Characters_Normal_Missed[i] = new CTexture[OpenTaiko.Skin.Characters_Normal_Missed_Ptn[i]];
			Characters_Normal_MissedDown[i] = new CTexture[OpenTaiko.Skin.Characters_Normal_MissedDown_Ptn[i]];
			Characters_Normal_Cleared[i] = new CTexture[OpenTaiko.Skin.Characters_Normal_Cleared_Ptn[i]];
			Characters_Normal_Maxed[i] = new CTexture[OpenTaiko.Skin.Characters_Normal_Maxed_Ptn[i]];
			Characters_MissIn[i] = new CTexture[OpenTaiko.Skin.Characters_MissIn_Ptn[i]];
			Characters_MissDownIn[i] = new CTexture[OpenTaiko.Skin.Characters_MissDownIn_Ptn[i]];
			Characters_GoGoTime[i] = new CTexture[OpenTaiko.Skin.Characters_GoGoTime_Ptn[i]];
			Characters_GoGoTime_Maxed[i] = new CTexture[OpenTaiko.Skin.Characters_GoGoTime_Maxed_Ptn[i]];
			Characters_10Combo[i] = new CTexture[OpenTaiko.Skin.Characters_10Combo_Ptn[i]];
			Characters_10Combo_Clear[i] = new CTexture[OpenTaiko.Skin.Characters_10Combo_Clear_Ptn[i]];
			Characters_10Combo_Maxed[i] = new CTexture[OpenTaiko.Skin.Characters_10Combo_Maxed_Ptn[i]];
			Characters_GoGoStart[i] = new CTexture[OpenTaiko.Skin.Characters_GoGoStart_Ptn[i]];
			Characters_GoGoStart_Clear[i] = new CTexture[OpenTaiko.Skin.Characters_GoGoStart_Clear_Ptn[i]];
			Characters_GoGoStart_Maxed[i] = new CTexture[OpenTaiko.Skin.Characters_GoGoStart_Maxed_Ptn[i]];
			Characters_Become_Cleared[i] = new CTexture[OpenTaiko.Skin.Characters_Become_Cleared_Ptn[i]];
			Characters_Become_Maxed[i] = new CTexture[OpenTaiko.Skin.Characters_Become_Maxed_Ptn[i]];
			Characters_SoulOut[i] = new CTexture[OpenTaiko.Skin.Characters_SoulOut_Ptn[i]];
			Characters_ClearOut[i] = new CTexture[OpenTaiko.Skin.Characters_ClearOut_Ptn[i]];
			Characters_Return[i] = new CTexture[OpenTaiko.Skin.Characters_Return_Ptn[i]];
			Characters_Balloon_Breaking[i] = new CTexture[OpenTaiko.Skin.Characters_Balloon_Breaking_Ptn[i]];
			Characters_Balloon_Broke[i] = new CTexture[OpenTaiko.Skin.Characters_Balloon_Broke_Ptn[i]];
			Characters_Balloon_Miss[i] = new CTexture[OpenTaiko.Skin.Characters_Balloon_Miss_Ptn[i]];
			Characters_Kusudama_Idle[i] = new CTexture[OpenTaiko.Skin.Characters_Kusudama_Idle_Ptn[i]];
			Characters_Kusudama_Breaking[i] = new CTexture[OpenTaiko.Skin.Characters_Kusudama_Breaking_Ptn[i]];
			Characters_Kusudama_Broke[i] = new CTexture[OpenTaiko.Skin.Characters_Kusudama_Broke_Ptn[i]];
			Characters_Kusudama_Miss[i] = new CTexture[OpenTaiko.Skin.Characters_Kusudama_Miss_Ptn[i]];
			Characters_Title_Entry[i] = new CTexture[OpenTaiko.Skin.Characters_Title_Entry_Ptn[i]];
			Characters_Title_Normal[i] = new CTexture[OpenTaiko.Skin.Characters_Title_Normal_Ptn[i]];
			Characters_Result_Clear[i] = new CTexture[OpenTaiko.Skin.Characters_Result_Clear_Ptn[i]];
			Characters_Result_Failed[i] = new CTexture[OpenTaiko.Skin.Characters_Result_Failed_Ptn[i]];
			Characters_Result_Failed_In[i] = new CTexture[OpenTaiko.Skin.Characters_Result_Failed_In_Ptn[i]];
			Characters_Result_Normal[i] = new CTexture[OpenTaiko.Skin.Characters_Result_Normal_Ptn[i]];
			Characters_Menu_Loop[i] = new CTexture[OpenTaiko.Skin.Characters_Menu_Loop_Ptn[i]];
			Characters_Menu_Start[i] = new CTexture[OpenTaiko.Skin.Characters_Menu_Start_Ptn[i]];
			Characters_Menu_Select[i] = new CTexture[OpenTaiko.Skin.Characters_Menu_Select_Ptn[i]];
			Characters_Menu_Wait[i] = new CTexture[OpenTaiko.Skin.Characters_Menu_Wait_Ptn[i]];
			Characters_Tower_Standing[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Standing_Ptn[i]];
			Characters_Tower_Climbing[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Climbing_Ptn[i]];
			Characters_Tower_Running[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Running_Ptn[i]];
			Characters_Tower_Clear[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Clear_Ptn[i]];
			Characters_Tower_Fail[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Fail_Ptn[i]];
			Characters_Tower_Standing_Tired[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Standing_Tired_Ptn[i]];
			Characters_Tower_Climbing_Tired[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Climbing_Tired_Ptn[i]];
			Characters_Tower_Running_Tired[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Running_Tired_Ptn[i]];
			Characters_Tower_Clear_Tired[i] = new CTexture[OpenTaiko.Skin.Characters_Tower_Clear_Tired_Ptn[i]];

			#endregion

			#region [Characters asset loading]

			for (int j = 0; j < OpenTaiko.Skin.Characters_Menu_Loop_Ptn[i]; j++)
				Characters_Menu_Loop[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Menu_Loop{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Menu_Select_Ptn[i]; j++)
				Characters_Menu_Select[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Menu_Select{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Menu_Start_Ptn[i]; j++)
				Characters_Menu_Start[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Menu_Start{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Menu_Wait_Ptn[i]; j++)
				Characters_Menu_Wait[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Menu_Wait{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Result_Normal_Ptn[i]; j++)
				Characters_Result_Normal[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Result_Normal{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Result_Failed_In_Ptn[i]; j++)
				Characters_Result_Failed_In[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Result_Failed_In{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Result_Failed_Ptn[i]; j++)
				Characters_Result_Failed[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Result_Failed{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Result_Clear_Ptn[i]; j++)
				Characters_Result_Clear[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Result_Clear{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Title_Normal_Ptn[i]; j++)
				Characters_Title_Normal[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Title_Normal{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Title_Entry_Ptn[i]; j++)
				Characters_Title_Entry[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Title_Entry{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_Ptn[i]; j++)
				Characters_Normal[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Normal{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_Missed_Ptn[i]; j++)
				Characters_Normal_Missed[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Miss{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_MissedDown_Ptn[i]; j++)
				Characters_Normal_MissedDown[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}MissDown{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_Cleared_Ptn[i]; j++)
				Characters_Normal_Cleared[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Normal_Maxed_Ptn[i]; j++)
				Characters_Normal_Maxed[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Clear_Max{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_MissIn_Ptn[i]; j++)
				Characters_MissIn[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}MissIn{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_MissDownIn_Ptn[i]; j++)
				Characters_MissDownIn[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}MissDownIn{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoTime_Ptn[i]; j++)
				Characters_GoGoTime[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}GoGo{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoTime_Maxed_Ptn[i]; j++)
				Characters_GoGoTime_Maxed[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}GoGo_Max{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoStart_Ptn[i]; j++)
				Characters_GoGoStart[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}GoGoStart{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoStart_Clear_Ptn[i]; j++)
				Characters_GoGoStart_Clear[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}GoGoStart_Clear{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_GoGoStart_Maxed_Ptn[i]; j++)
				Characters_GoGoStart_Maxed[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}GoGoStart_Max{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_10Combo_Ptn[i]; j++)
				Characters_10Combo[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}10combo{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_10Combo_Clear_Ptn[i]; j++)
				Characters_10Combo_Clear[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}10combo_Clear{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_10Combo_Maxed_Ptn[i]; j++)
				Characters_10Combo_Maxed[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}10combo_Max{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Become_Cleared_Ptn[i]; j++)
				Characters_Become_Cleared[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Clearin{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Become_Maxed_Ptn[i]; j++)
				Characters_Become_Maxed[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Soulin{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_SoulOut_Ptn[i]; j++)
				Characters_SoulOut[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Soulout{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_ClearOut_Ptn[i]; j++)
				Characters_ClearOut[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Clearout{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Return_Ptn[i]; j++)
				Characters_Return[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Return{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Balloon_Breaking_Ptn[i]; j++)
				Characters_Balloon_Breaking[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Balloon_Breaking{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Balloon_Broke_Ptn[i]; j++)
				Characters_Balloon_Broke[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Balloon_Broke{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Balloon_Miss_Ptn[i]; j++)
				Characters_Balloon_Miss[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Balloon_Miss{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Kusudama_Idle_Ptn[i]; j++)
				Characters_Kusudama_Idle[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Kusudama_Idle{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Kusudama_Breaking_Ptn[i]; j++)
				Characters_Kusudama_Breaking[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Kusudama_Breaking{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Kusudama_Broke_Ptn[i]; j++)
				Characters_Kusudama_Broke[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Kusudama_Broke{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Kusudama_Miss_Ptn[i]; j++)
				Characters_Kusudama_Miss[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Kusudama_Miss{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Standing_Ptn[i]; j++)
				Characters_Tower_Standing[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Standing{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Climbing_Ptn[i]; j++)
				Characters_Tower_Climbing[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Climbing{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Running_Ptn[i]; j++)
				Characters_Tower_Running[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Running{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Clear_Ptn[i]; j++)
				Characters_Tower_Clear[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Fail_Ptn[i]; j++)
				Characters_Tower_Fail[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Fail{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Standing_Tired_Ptn[i]; j++)
				Characters_Tower_Standing_Tired[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Standing_Tired{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Climbing_Tired_Ptn[i]; j++)
				Characters_Tower_Climbing_Tired[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Climbing_Tired{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Running_Tired_Ptn[i]; j++)
				Characters_Tower_Running_Tired[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Running_Tired{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			for (int j = 0; j < OpenTaiko.Skin.Characters_Tower_Clear_Tired_Ptn[i]; j++)
				Characters_Tower_Clear_Tired[i][j] = TxCGlobal(CHARACTERS + OpenTaiko.Skin.Characters_DirName[i] + @$"{Path.DirectorySeparatorChar}Tower_Char{Path.DirectorySeparatorChar}Clear_Tired{Path.DirectorySeparatorChar}" + j.ToString() + @$".png");

			#endregion

			#region [Parse individual character parameters]

			#region [Default values]

			OpenTaiko.Skin.Characters_Menu_Offset[i] = new int[] { 0, 0 };
			OpenTaiko.Skin.Characters_Result_Offset[i] = new int[] { 0, 0 };
			OpenTaiko.Skin.Characters_X[i] = new int[] { 0, 0 };
			OpenTaiko.Skin.Characters_Y[i] = new int[] { 0, 537 };
			OpenTaiko.Skin.Characters_4P[i] = new int[] { 165, 68 };
			OpenTaiko.Skin.Characters_5P[i] = new int[] { 165, 40 };
			OpenTaiko.Skin.Characters_X_AI[i] = new int[] { 472, 602 };
			OpenTaiko.Skin.Characters_Y_AI[i] = new int[] { 152, 152 };
			OpenTaiko.Skin.Characters_Balloon_X[i] = new int[] { 240, 240, 0, 0 };
			OpenTaiko.Skin.Characters_Balloon_Y[i] = new int[] { 0, 297, 0, 0 };
			OpenTaiko.Skin.Characters_Balloon_4P[i] = new int[] { 0, -176 };
			OpenTaiko.Skin.Characters_Balloon_5P[i] = new int[] { 0, -168 };
			OpenTaiko.Skin.Characters_Kusudama_X[i] = new int[] { 290, 690, 90, 890, 490 };
			OpenTaiko.Skin.Characters_Kusudama_Y[i] = new int[] { 420, 420, 420, 420, 420 };
			OpenTaiko.Skin.Characters_Motion_Normal[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_Normal_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_10Combo[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_10Combo_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_10Combo_Clear[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_10Combo_Clear_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_10ComboMax[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_10Combo_Maxed_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_Miss[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_Normal_Missed_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_MissDown[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_Normal_MissedDown_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_ClearIn[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_Become_Cleared_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_Clear[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_Normal_Cleared_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_ClearMax[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_Normal_Maxed_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_MissIn[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_MissIn_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_MissDownIn[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_MissDownIn_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_GoGoStart[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_GoGoStart_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_GoGoStart_Clear[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_GoGoStart_Clear_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_GoGoStartMax[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_GoGoStart_Maxed_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_GoGo[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_GoGoTime_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_GoGoMax[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_GoGoTime_Maxed_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_SoulIn[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_Become_Maxed_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_SoulOut[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_SoulOut_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_ClearOut[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_ClearOut_Ptn[i]);
			OpenTaiko.Skin.Characters_Motion_Return[i] = CreateNumberedArrayFromInt(OpenTaiko.Skin.Characters_Return_Ptn[i]);
			/*
            TJAPlayer3.Skin.Characters_Motion_Tower_Standing[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Standing_Ptn[i]);
            TJAPlayer3.Skin.Characters_Motion_Tower_Climbing[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Climbing_Ptn[i]);
            TJAPlayer3.Skin.Characters_Motion_Tower_Running[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Running_Ptn[i]);
            TJAPlayer3.Skin.Characters_Motion_Tower_Clear[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Clear_Ptn[i]);
            TJAPlayer3.Skin.Characters_Motion_Tower_Fail[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Fail_Ptn[i]);
            TJAPlayer3.Skin.Characters_Motion_Tower_Standing_Tired[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Standing_Tired_Ptn[i]);
            TJAPlayer3.Skin.Characters_Motion_Tower_Climbing_Tired[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Climbing_Tired_Ptn[i]);
            TJAPlayer3.Skin.Characters_Motion_Tower_Running_Tired[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Running_Tired_Ptn[i]);
            TJAPlayer3.Skin.Characters_Motion_Tower_Clear_Tired[i] = CreateNumberedArrayFromInt(TJAPlayer3.Skin.Characters_Tower_Clear_Tired_Ptn[i]);
            */
			OpenTaiko.Skin.Characters_Beat_Normal[i] = 1;
			OpenTaiko.Skin.Characters_Beat_Miss[i] = 1;
			OpenTaiko.Skin.Characters_Beat_MissDown[i] = 1;
			OpenTaiko.Skin.Characters_Beat_Clear[i] = 2;
			OpenTaiko.Skin.Characters_Beat_GoGo[i] = 2;
			OpenTaiko.Skin.Characters_Beat_MissIn[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_MissDownIn[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_10Combo[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_10Combo_Clear[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_10ComboMax[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_ClearIn[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_ClearMax[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_GoGoStart[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_GoGoStart_Clear[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_GoGoStartMax[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_GoGoMax[i] = 2;
			OpenTaiko.Skin.Characters_Beat_SoulIn[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_SoulOut[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_ClearOut[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_Return[i] = 1.5f;
			OpenTaiko.Skin.Characters_Beat_Tower_Standing[i] = 1;
			OpenTaiko.Skin.Characters_Beat_Tower_Clear[i] = 1;
			OpenTaiko.Skin.Characters_Beat_Tower_Fail[i] = 1;
			OpenTaiko.Skin.Characters_Beat_Tower_Standing_Tired[i] = 1;
			OpenTaiko.Skin.Characters_Beat_Tower_Clear_Tired[i] = 1;
			OpenTaiko.Skin.Characters_Balloon_Timer[i] = 28;
			OpenTaiko.Skin.Characters_Balloon_Delay[i] = 500;
			OpenTaiko.Skin.Characters_Balloon_FadeOut[i] = 84;
			OpenTaiko.Skin.Characters_Title_Entry_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Title_Normal_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Menu_Loop_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Menu_Select_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Menu_Start_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Menu_Wait_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Result_Normal_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Result_Clear_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Result_Failed_In_AnimationDuration[i] = 1000;
			OpenTaiko.Skin.Characters_Result_Failed_AnimationDuration[i] = 1000;

			#endregion

			var _str = "";
			OpenTaiko.Skin.LoadSkinConfigFromFile(charaPath + @$"{Path.DirectorySeparatorChar}CharaConfig.txt", ref _str);

			string[] delimiter = { "\n" };
			string[] strSingleLine = _str.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

			foreach (string s in strSingleLine) {
				string str = s.Replace('\t', ' ').TrimStart(new char[] { '\t', ' ' });
				if ((str.Length != 0) && (str[0] != ';')) {
					try {
						string strCommand;
						string strParam;
						string[] strArray = str.Split(new char[] { '=' });

						if (strArray.Length == 2) {
							strCommand = strArray[0].Trim();
							strParam = strArray[1].Trim();

							switch (strCommand) {
								case "Menu_Offset": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_Menu_Offset[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Result_Offset": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_Result_Offset[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_X": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_X[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Y": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_Y[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_4P": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_4P[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_5P": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_5P[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_X_AI": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_X_AI[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Y_AI": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_Y_AI[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Balloon_X": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_Balloon_X[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Balloon_Y": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_Balloon_Y[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Balloon_4P": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_Balloon_4P[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Balloon_5P": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 2; k++) {
											OpenTaiko.Skin.Characters_Balloon_5P[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Kusudama_X": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 5; k++) {
											OpenTaiko.Skin.Characters_Kusudama_X[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Kusudama_Y": {
										string[] strSplit = strParam.Split(',');
										for (int k = 0; k < 5; k++) {
											OpenTaiko.Skin.Characters_Kusudama_Y[i][k] = int.Parse(strSplit[k]);
										}
										break;
									}
								case "Game_Chara_Balloon_Timer": {
										if (int.Parse(strParam) > 0)
											OpenTaiko.Skin.Characters_Balloon_Timer[i] = int.Parse(strParam);
										break;
									}
								case "Game_Chara_Balloon_Delay": {
										if (int.Parse(strParam) > 0)
											OpenTaiko.Skin.Characters_Balloon_Delay[i] = int.Parse(strParam);
										break;
									}
								case "Game_Chara_Balloon_FadeOut": {
										if (int.Parse(strParam) > 0)
											OpenTaiko.Skin.Characters_Balloon_FadeOut[i] = int.Parse(strParam);
										break;
									}
								// パターン数の設定はTextureLoader.csで反映されます。
								case "Game_Chara_Motion_Normal": {
										OpenTaiko.Skin.Characters_Motion_Normal[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_10Combo": {
										OpenTaiko.Skin.Characters_Motion_10Combo[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_10Combo_Clear": {
										OpenTaiko.Skin.Characters_Motion_10Combo_Clear[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_10Combo_Max": {
										OpenTaiko.Skin.Characters_Motion_10ComboMax[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_Miss": {
										OpenTaiko.Skin.Characters_Motion_Miss[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_MissDown": {
										OpenTaiko.Skin.Characters_Motion_MissDown[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_ClearIn": {
										OpenTaiko.Skin.Characters_Motion_ClearIn[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_Clear": {
										OpenTaiko.Skin.Characters_Motion_Clear[i] = CConversion.StringToIntArray(strParam);
										OpenTaiko.Skin.Characters_Motion_ClearMax[i] = OpenTaiko.Skin.Characters_Motion_Clear[i];
										break;
									}
								case "Game_Chara_Motion_ClearMax": {
										OpenTaiko.Skin.Characters_Motion_ClearMax[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_MissIn": {
										OpenTaiko.Skin.Characters_Motion_MissIn[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_MissDownIn": {
										OpenTaiko.Skin.Characters_Motion_MissDownIn[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_GoGoStart": {
										OpenTaiko.Skin.Characters_Motion_GoGoStart[i] = CConversion.StringToIntArray(strParam);
										OpenTaiko.Skin.Characters_Motion_GoGoStartMax[i] = OpenTaiko.Skin.Characters_Motion_GoGoStart[i];
										break;
									}
								case "Game_Chara_Motion_GoGoStart_Clear": {
										OpenTaiko.Skin.Characters_Motion_GoGoStart_Clear[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_GoGoStart_Max": {
										OpenTaiko.Skin.Characters_Motion_GoGoStartMax[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_GoGo": {
										OpenTaiko.Skin.Characters_Motion_GoGo[i] = CConversion.StringToIntArray(strParam);
										OpenTaiko.Skin.Characters_Motion_GoGoMax[i] = OpenTaiko.Skin.Characters_Motion_GoGo[i];
										break;
									}
								case "Game_Chara_Motion_GoGo_Max": {
										OpenTaiko.Skin.Characters_Motion_GoGoMax[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_SoulIn": {
										OpenTaiko.Skin.Characters_Motion_SoulIn[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_SoulOut": {
										OpenTaiko.Skin.Characters_Motion_SoulOut[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_ClearOut": {
										OpenTaiko.Skin.Characters_Motion_ClearOut[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								case "Game_Chara_Motion_Return": {
										OpenTaiko.Skin.Characters_Motion_Return[i] = CConversion.StringToIntArray(strParam);
										break;
									}
								/*case "Game_Chara_Motion_Tower_Standing":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Standing[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }
                                case "Game_Chara_Motion_Tower_Climbing":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Climbing[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }
                                case "Game_Chara_Motion_Tower_Running":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Running[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }
                                case "Game_Chara_Motion_Tower_Clear":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Clear[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }
                                case "Game_Chara_Motion_Tower_Fail":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Fail[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }
                                case "Game_Chara_Motion_Tower_Standing_Tired":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Standing_Tired[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }
                                case "Game_Chara_Motion_Tower_Climbing_Tired":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Climbing_Tired[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }
                                case "Game_Chara_Motion_Tower_Running_Tired":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Running_Tired[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }
                                case "Game_Chara_Motion_Tower_Clear_Tired":
                                {
                                    TJAPlayer3.Skin.Characters_Motion_Tower_Clear_Tired[i] = CConversion.StringToIntArray(strParam);
                                    break;
                                }*/
								case "Game_Chara_Beat_Normal": {
										OpenTaiko.Skin.Characters_Beat_Normal[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_10Combo": {
										OpenTaiko.Skin.Characters_Beat_10Combo[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_10ComboMax": {
										OpenTaiko.Skin.Characters_Beat_10ComboMax[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_Miss": {
										OpenTaiko.Skin.Characters_Beat_Miss[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_MissDown": {
										OpenTaiko.Skin.Characters_Beat_MissDown[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_ClearIn": {
										OpenTaiko.Skin.Characters_Beat_ClearIn[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_Clear": {
										OpenTaiko.Skin.Characters_Beat_Clear[i] = float.Parse(strParam);
										OpenTaiko.Skin.Characters_Beat_ClearMax[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_ClearMax": {
										OpenTaiko.Skin.Characters_Beat_ClearMax[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_MissIn": {
										OpenTaiko.Skin.Characters_Beat_MissIn[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_MissDownIn": {
										OpenTaiko.Skin.Characters_Beat_MissDownIn[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_GoGoStart": {
										OpenTaiko.Skin.Characters_Beat_GoGoStart[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_GoGoStartClear": {
										OpenTaiko.Skin.Characters_Beat_GoGoStart_Clear[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_GoGoStartMax": {
										OpenTaiko.Skin.Characters_Beat_GoGoStartMax[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_GoGo": {
										OpenTaiko.Skin.Characters_Beat_GoGo[i] = float.Parse(strParam);
										OpenTaiko.Skin.Characters_Beat_GoGoMax[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_GoGoMax": {
										OpenTaiko.Skin.Characters_Beat_GoGoMax[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_SoulIn": {
										OpenTaiko.Skin.Characters_Beat_SoulIn[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_Return": {
										OpenTaiko.Skin.Characters_Beat_Return[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_Tower_Standing": {
										OpenTaiko.Skin.Characters_Beat_Tower_Standing[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_Tower_Standing_Tired": {
										OpenTaiko.Skin.Characters_Beat_Tower_Standing_Tired[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_Tower_Fail": {
										OpenTaiko.Skin.Characters_Beat_Tower_Fail[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_Tower_Clear": {
										OpenTaiko.Skin.Characters_Beat_Tower_Clear[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Beat_Tower_Clear_Tired": {
										OpenTaiko.Skin.Characters_Beat_Tower_Clear_Tired[i] = float.Parse(strParam);
										break;
									}
								case "Game_Chara_Tower_Clear_IsLooping": {
										OpenTaiko.Skin.Characters_Tower_Clear_IsLooping[i] = int.Parse(strParam) != 0;
										break;
									}
								case "Game_Chara_Tower_Clear_Tired_IsLooping": {
										OpenTaiko.Skin.Characters_Tower_Clear_Tired_IsLooping[i] = int.Parse(strParam) != 0;
										break;
									}
								case "Game_Chara_Tower_Fail_IsLooping": {
										OpenTaiko.Skin.Characters_Tower_Fail_IsLooping[i] = int.Parse(strParam) != 0;
										break;
									}
								case "Chara_Entry_AnimationDuration": {
										OpenTaiko.Skin.Characters_Title_Entry_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Normal_AnimationDuration": {
										OpenTaiko.Skin.Characters_Title_Normal_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Menu_Loop_AnimationDuration": {
										OpenTaiko.Skin.Characters_Menu_Loop_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Menu_Select_AnimationDuration": {
										OpenTaiko.Skin.Characters_Menu_Select_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Menu_Start_AnimationDuration": {
										OpenTaiko.Skin.Characters_Menu_Start_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Menu_Wait_AnimationDuration": {
										OpenTaiko.Skin.Characters_Menu_Wait_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Result_Normal_AnimationDuration": {
										OpenTaiko.Skin.Characters_Result_Normal_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Result_Clear_AnimationDuration": {
										OpenTaiko.Skin.Characters_Result_Clear_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Result_Failed_In_AnimationDuration": {
										OpenTaiko.Skin.Characters_Result_Failed_In_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								case "Chara_Result_Failed_AnimationDuration": {
										OpenTaiko.Skin.Characters_Result_Failed_AnimationDuration[i] = int.Parse(strParam);
										break;
									}
								/*
                                case "Chara_Result_SpeechText":
                                {
                                    string[] strSplit = strParam.Split(',');
                                    for (int j = 0; j < 6; j++)
                                    {
                                        TJAPlayer3.Skin.Characters_Result_SpeechText[i][j] = strSplit[j];
                                    }
                                    break;
                                }
                                */
								default: { break; }
							}
						}
						continue;
					} catch (Exception exception) {
						Trace.TraceError(exception.ToString());
						Trace.TraceError("例外が発生しましたが処理を継続します。 (6a32cc37-1527-412e-968a-512c1f0135cd)");
						continue;
					}
				}
			}

			#endregion

			#endregion
		}

		#region [Voice samples]

		var _skin = OpenTaiko.Skin;

		#region [Dispose previously allocated sound effects]

		_skin.voiceClearFailed[player]?.Dispose();
		_skin.voiceClearClear[player]?.Dispose();
		_skin.voiceClearFullCombo[player]?.Dispose();
		_skin.voiceClearAllPerfect[player]?.Dispose();
		_skin.voiceAIWin[player]?.Dispose();
		_skin.voiceAILose[player]?.Dispose();
		_skin.voiceMenuSongSelect[player]?.Dispose();
		_skin.voiceMenuSongDecide[player]?.Dispose();
		_skin.voiceMenuSongDecide_AI[player]?.Dispose();
		_skin.voiceMenuDiffSelect[player]?.Dispose();
		_skin.voiceMenuDanSelectStart[player]?.Dispose();
		_skin.voiceMenuDanSelectPrompt[player]?.Dispose();
		_skin.voiceMenuDanSelectConfirm[player]?.Dispose();
		_skin.voiceTitleSanka[player]?.Dispose();
		_skin.voiceTowerMiss[player]?.Dispose();
		_skin.voiceResultBestScore[player]?.Dispose();
		_skin.voiceResultClearFailed[player]?.Dispose();
		_skin.voiceResultClearSuccess[player]?.Dispose();
		_skin.voiceResultDanFailed[player]?.Dispose();
		_skin.voiceResultDanRedPass[player]?.Dispose();
		_skin.voiceResultDanGoldPass[player]?.Dispose();

		#endregion

		#region [Allocate and load the new samples]

		_skin.voiceClearFailed[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}Failed");
		_skin.voiceClearClear[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}Clear");
		_skin.voiceClearFullCombo[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}FullCombo");
		_skin.voiceClearAllPerfect[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}AllPerfect");
		_skin.voiceAIWin[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}AIBattle_Win");
		_skin.voiceAILose[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Clear{Path.DirectorySeparatorChar}AIBattle_Lose");
		_skin.voiceMenuSongSelect[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Menu{Path.DirectorySeparatorChar}SongSelect");
		_skin.voiceMenuSongDecide[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Menu{Path.DirectorySeparatorChar}SongDecide");
		_skin.voiceMenuSongDecide_AI[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Menu{Path.DirectorySeparatorChar}SongDecide_AI");
		_skin.voiceMenuDiffSelect[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Menu{Path.DirectorySeparatorChar}DiffSelect");
		_skin.voiceMenuDanSelectStart[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Menu{Path.DirectorySeparatorChar}DanSelectStart");
		_skin.voiceMenuDanSelectPrompt[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Menu{Path.DirectorySeparatorChar}DanSelectPrompt");
		_skin.voiceMenuDanSelectConfirm[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Menu{Path.DirectorySeparatorChar}DanSelectConfirm");
		_skin.voiceTitleSanka[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Title{Path.DirectorySeparatorChar}Sanka");
		_skin.voiceTowerMiss[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Tower{Path.DirectorySeparatorChar}Miss");
		_skin.voiceResultBestScore[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Result{Path.DirectorySeparatorChar}BestScore");
		_skin.voiceResultClearFailed[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Result{Path.DirectorySeparatorChar}ClearFailed");
		_skin.voiceResultClearSuccess[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Result{Path.DirectorySeparatorChar}ClearSuccess");
		_skin.voiceResultDanFailed[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Result{Path.DirectorySeparatorChar}DanFailed");
		_skin.voiceResultDanRedPass[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Result{Path.DirectorySeparatorChar}DanRedPass");
		_skin.voiceResultDanGoldPass[player] = VoiceSelectOggOrWav(charaPath + @$"{Path.DirectorySeparatorChar}Sounds{Path.DirectorySeparatorChar}Result{Path.DirectorySeparatorChar}DanGoldPass");

		#endregion

		#endregion
	}

	public void DisposeTexture() {
		foreach (var tex in listTexture) {
			var texture = tex;
			OpenTaiko.tテクスチャの解放(ref texture);
			texture?.Dispose();
			texture = null;
		}
		listTexture.Clear();

		//if (TJAPlayer3.ConfigIni.PreAssetsLoading)
		{
			foreach (var act in OpenTaiko.app.listTopLevelActivities) {
				act.ReleaseManagedResource();
				act.ReleaseUnmanagedResource();
			}
		}
	}
	#region Calibration

	public CTexture CalibrateFG,
		CalibrateBG;

	#endregion

	#region 共通
	public CTexture Tile_Black,
		Menu_Title,
		Menu_Highlight,
		Enum_Song,
		Loading,
		Scanning_Loudness,
		NamePlateBase,
		NamePlate_Extension,
		Overlay,
		Readme,
		Network_Connection;

	#endregion

	#region 1_タイトル画面

	public CTexture
		//Title_Background,
		Entry_Bar,
		Entry_Bar_Text;

	public CTexture[] Banapas_Load = new CTexture[3];
	public CTexture[] Banapas_Load_Clear = new CTexture[2];
	public CTexture[] Banapas_Load_Failure = new CTexture[2];
	public CTexture[] Entry_Player = new CTexture[3];
	public CTexture[] ModeSelect_Bar;
	public CTexture[] ModeSelect_Bar_Chara;

	#endregion

	#region 2_コンフィグ画面
	public CTexture
		/*Config_Background,
        Config_Header,*/
		Config_Cursor,
		Config_ItemBox,
		Config_Arrow,
		Config_KeyAssign,
		Config_Font,
		Config_Font_Bold,
		Config_Enum_Song;
	#endregion

	#region 3_選曲画面

	public CTexture SongSelect_Background,
		SongSelect_Header,
		SongSelect_Footer,
		SongSelect_Auto,
		SongSelect_Level,
		SongSelect_Branch,
		SongSelect_Branch_Text,
		SongSelect_Lock,
		SongSelect_Frame_Box,
		SongSelect_Frame_BackBox,
		SongSelect_Frame_Random,
		SongSelect_Bar_Center,
		SongSelect_Bar_Genre_Back,
		SongSelect_Bar_Genre_Locked,
		SongSelect_Bar_Genre_Locked_Top,
		SongSelect_Bar_Genre_Random,
		SongSelect_Bar_Genre_RecentryPlaySong,
		SongSelect_Level_Number,
		SongSelect_Level_Number_Colored,
		SongSelect_Level_Number_Icon,
		SongSelect_Level_Number_Big,
		SongSelect_Level_Number_Big_Colored,
		SongSelect_Level_Number_Big_Icon,
		SongSelect_Bpm_Number,
		SongSelect_Floor_Number,
		SongSelect_Bar_Select,
		SongSelect_Bar_Genre_Overlay,
		SongSelect_Credit,
		SongSelect_Timer,
		SongSelect_Explicit,
		SongSelect_Movie,
		SongSelect_Crown,
		SongSelect_ScoreRank,
		SongSelect_Song_Number,
		SongSelect_BoardNumber,
		SongSelect_Difficulty_Cymbol,
		SongSelect_Unlock_Conditions,
		SongSelect_Tower_Side,

		SongSelect_Favorite,
		SongSelect_High_Score,

		SongSelect_Level_Icons,
		SongSelect_Search_Arrow,
		SongSelect_Search_Arrow_Glow,
		SongSelect_Search_Window,

		SongSelect_ScoreWindow_Text;
	public Dictionary<string, CTexture> SongSelect_GenreBack,
		SongSelect_Bar_Genre,
		SongSelect_Bar_Genre_Overlap,
		SongSelect_Box_Chara;
	public CTexture[]
		SongSelect_ScoreWindow = new CTexture[(int)Difficulty.Total],
		SongSelect_Frame_Score = new CTexture[3],
		SongSelect_NamePlate = new CTexture[1],
		SongSelect_Song_Panel = new CTexture[6],
		SongSelect_Coin_Slot = new CTexture[4],
		SongSelect_Table = new CTexture[6];

	#region [ 難易度選択画面 ]
	public CTexture Difficulty_Bar;
	public CTexture Difficulty_Number;
	public CTexture Difficulty_Number_Colored;
	public CTexture Difficulty_Number_Icon;
	public CTexture Difficulty_Star;
	public CTexture Difficulty_Crown;
	public CTexture Difficulty_Option;
	public CTexture Difficulty_Option_Select;

	public CTexture[] Difficulty_Select_Bar = new CTexture[5];
	public Dictionary<string, CTexture> Difficulty_Back;
	#endregion

	public CTexture NewHeya_Close;
	public CTexture NewHeya_Close_Select;
	public CTexture[] NewHeya_PlayerPlate = new CTexture[5];
	public CTexture NewHeya_PlayerPlate_Select;
	public CTexture NewHeya_ModeBar;
	public CTexture NewHeya_ModeBar_Select;
	public CTexture NewHeya_Box;
	public CTexture NewHeya_Lock;

	#endregion

	#region 3_段位選択画面

	//public CTexture Dani_Background;
	public CTexture Dani_Difficulty_Cymbol;
	public CTexture Dani_Level_Number;
	public CTexture Dani_Soul_Number;
	public CTexture Dani_Exam_Number;
	public CTexture Dani_Bar_Center;
	public CTexture Dani_Bar_Back;
	public CTexture Dani_Bar_Folder;
	public CTexture Dani_Bar_Folder_Back;
	public CTexture Dani_Bar_Random;
	public CTexture Dani_Plate;
	public CTexture Dani_Plate_Extra;

	public CTexture[] Challenge_Select = new CTexture[3];

	//public CTexture Dani_Dan_In;
	//public CTexture Dani_Dan_Text;

	public CTexture Dani_DanPlates;
	public CTexture Dani_DanPlates_Back;
	public CTexture Dani_DanIcon;
	public CTexture Dani_DanIcon_Fade;
	public CTexture Dani_DanSides;
	public CTexture[] Dani_Bloc = new CTexture[4];

	#endregion

	#region 4_読み込み画面
	public CTexture SongLoading_Plate,
		SongLoading_Bg,
		SongLoading_BgWait,
		SongLoading_Chara,
		SongLoading_Bg_Dan,
		SongLoading_Fade,

		SongLoading_Plate_AI,
		SongLoading_Bg_AI,
		SongLoading_Bg_AI_Wait,
		SongLoading_Fade_AI,
		SongLoading_Fade_AI_Anime_Base,
		SongLoading_Fade_AI_Anime_Ring,
		SongLoading_Fade_AI_Anime_NowLoading,
		SongLoading_Fade_AI_Anime_Start,
		SongLoading_Fade_AI_Anime_LoadBar_Base,
		SongLoading_Fade_AI_Anime_LoadBar;
	#endregion

	#region 5_演奏画面
	#region 共通
	public CTexture Judge_Frame,
		Note_Mine,
		Note_Swap,
		Note_Kusu,
		Note_FuseRoll,
		Note_Adlib,
		SENotesExtension,
		Notes_Arm,
		ChipEffect,
		ScoreRank,
		Judge;
	public CTexture Judge_Meter,
		Bar,
		Bar_Branch;
	public CTexture[] Notes,
		SENotes;
	#endregion


	#region モブ
	#endregion
	#region 太鼓
	public CTexture[] Taiko_Base,
		Taiko_Frame, // MTaiko下敷き
		Taiko_Background;
	public CTexture Taiko_Don_Left,
		Taiko_Don_Right,
		Taiko_Ka_Left,
		Taiko_Ka_Right,
		Taiko_Konga_Don,
		Taiko_Konga_Ka,
		Taiko_Konga_Clap,
		Taiko_LevelUp,
		Taiko_LevelDown,
		Taiko_Combo_Effect,
		Taiko_Combo_Text;
	public CTexture[] Couse_Symbol, // コースシンボル
		Couse_Symbol_Back,
		Couse_Symbol_Back_Flash,
		Taiko_PlayerNumber,
		Taiko_NamePlate; // ネームプレート
	public CTexture[] Taiko_Score,
		Taiko_Combo,
		Taiko_Combo_Guide;
	#endregion
	#region ゲージ
	public CTexture[] Gauge,
		Gauge_Base,
		Gauge_Base_Norma,
		Gauge_Line,
		Gauge_Rainbow,
		Gauge_Rainbow_2PGauge,
		Gauge_Rainbow_Flat,
		Gauge_Clear,
		Gauge_Killzone,
		Gauge_Soul_Explosion;
	public CTexture Gauge_Soul,
		Gauge_Soul_Fire;
	public CTexture[] Gauge_Dan;
	public CTexture[] Gauge_Dan_Rainbow;
	#endregion
	#region 吹き出し
	public CTexture[] Balloon_Combo;
	public CTexture Balloon_Roll,
		Balloon_Balloon,
		Balloon_Number_Roll,
		Balloon_Number_Combo/*,*/
		/*Balloon_Broken*/;
	public CTexture Kusudama_Number;

	public CTexture Fuse_Number,
		Fuse_Balloon;

	public CTexture[] Balloon_Breaking;
	#endregion
	#region エフェクト
	public CTexture Effects_Hit_Explosion,
		Effects_Hit_Bomb,
		Effects_Hit_Explosion_Big,
		Effects_Fire,
		Effects_Rainbow,
		Effects_GoGoSplash,
		Effects_Hit_FireWorks;
	public CTexture[] Effects_Hit_Great,
		Effects_Hit_Good,
		Effects_Hit_Great_Big,
		Effects_Hit_Good_Big;
	public CTexture[] Effects_Roll;
	#endregion
	#region レーン
	public CTexture[] Lane_Red,
		Lane_Blue,
		Lane_Clap,
		Lane_Base,
		Lane_Text;
	public CTexture Lane_Yellow;
	public CTexture Lane_Background_Main,
		Lane_Background_AI,
		Lane_Background_Sub,
		Lane_Background_GoGo;
	#endregion
	#region ゲームモード
	public CTexture GameMode_Timer_Frame,
		GameMode_Timer_Tick;
	#endregion
	#region ステージ失敗
	public CTexture Failed_Game,
		Failed_Stage;
	#endregion
	#region ランナー
	//public CTexture Runner;
	#endregion
	#region DanC
	public CTexture DanC_Background;
	public CTexture[] DanC_Gauge;
	public CTexture DanC_Base;
	public CTexture DanC_Base_Small;


	public CTexture DanC_Gauge_Base;
	public CTexture DanC_Failed;
	public CTexture DanC_Number,
		DanC_Small_Number,
		DanC_SmallBase,
		DanC_ExamType,
		DanC_ExamRange,
		DanC_Small_ExamCymbol,
		DanC_ExamCymbol,
		DanC_MiniNumber,
		DanC_ExamUnit;
	public CTexture DanC_Screen;
	#endregion
	#region PuchiChara

	public CPuchichara[] Puchichara;

	#endregion
	#region Training
	public CTexture Tokkun_DownBG,
		Tokkun_BigTaiko,
		Tokkun_ProgressBar,
		Tokkun_ProgressBarWhite,
		Tokkun_GoGoPoint,
		Tokkun_JumpPoint,
		Tokkun_Background_Up,
		Tokkun_BigNumber,
		Tokkun_SmallNumber,
		Tokkun_Speed_Measure;
	#endregion

	#region [20_Tower]

	public CTexture Tower_Miss;

	public CTexture[] Tower_Top;

	public CTexture[][] Tower_Base,
		Tower_Deco;


	#endregion

	#region [21_ModIcons]

	public CTexture[] Mod_Timing,
		Mod_SongSpeed,
		Mod_Fun,
		HiSp;
	public CTexture Mod_None,
		Mod_Doron,
		Mod_Stealth,
		Mod_Mirror,
		Mod_Random,
		Mod_Super,
		Mod_Hyper,
		Mod_Just,
		Mod_Safe,
		Mod_Auto;

	#endregion

	#region [22_AIBattle]

	public CTexture AIBattle_SectionTime_Panel,
		AIBattle_SectionTime_Bar_Base,
		AIBattle_SectionTime_Bar_Normal,
		AIBattle_SectionTime_Bar_Finish,
		AIBattle_Batch_Base,
		AIBattle_Batch,
		AIBattle_Judge_Number;

	public CTexture[] AIBattle_Judge_Meter = new CTexture[2];

	#endregion


	#endregion

	#region 6_結果発表
	public CTexture Result_Header,
		Result_Number,
		Result_Panel,
		Result_Panel_2P,
		Result_Soul_Text,
		Result_Soul_Fire,
		Result_Diff_Bar,
		Result_Score_Number,

		Result_CrownEffect,
		Result_ScoreRankEffect,

		//Result_Cloud,
		Result_Flower,
		Result_Shine,
		Result_Gauge_Frame,
		Result_Gauge_Clear,
		Result_Gauge_Clear_Base,
		Result_Gauge_Killzone,

		Result_Dan;

	public CTexture[]
		Result_Panel_5P = new CTexture[5],
		Result_Panel_4P = new CTexture[4],
		Result_Rainbow = new CTexture[41],
		//Result_Background = new CTexture[6],
		Result_Crown = new CTexture[3],

		Result_Flower_Rotate = new CTexture[5],
		//Result_Work = new CTexture[3],

		Result_Gauge = new CTexture[5],
		Result_Gauge_Base = new CTexture[5],
		Result_Speech_Bubble = new CTexture[2],
		Result_Speech_Bubble_V2 = new CTexture[3]
/*,
Result_Mountain = new CTexture[4]*/;
	#endregion

	#region 7_AIResults
	public CTexture Result_AIBattle_Panel_AI,
		Result_AIBattle_Batch,
		Result_AIBattle_SectionPlate,
		Result_AIBattle_WinFlag_Clear,
		Result_AIBattle_WinFlag_Lose;
	#endregion

	#region 7_終了画面
	//public CTexture Exit_Background/* , */
	/*Exit_Text; */
	#endregion

	#region [7_DanResults]

	public CTexture
		//DanResult_Background,
		DanResult_Rank,
		DanResult_SongPanel_Base,
		DanResult_StatePanel_Base,
		DanResult_SongPanel_Main,
		DanResult_StatePanel_Main;

	#endregion

	#region [8_TowerResults]

	public CTexture TowerResult_Background,
		TowerResult_ScoreRankEffect,
		TowerResult_Panel;
	public CTexture[]
		TowerResult_Tower;

	#endregion

	#region [10_Heya]

	public CTexture
		//Heya_Background,
		Heya_Center_Menu_Bar,
		Heya_Center_Menu_Box,
		Heya_Center_Menu_Box_Slot,
		Heya_Side_Menu,
		Heya_Box,
		Heya_Render_Field,
		Heya_Center_Menu_Background,
		Heya_Description_Panel,
		Heya_Lock;

	#endregion

	#region [11_Characters]

	public CTexture[][] Characters_Normal,
		Characters_Normal_Missed,
		Characters_Normal_MissedDown,
		Characters_Normal_Cleared,
		Characters_Normal_Maxed,
		Characters_MissIn,
		Characters_MissDownIn,
		Characters_GoGoTime,
		Characters_GoGoTime_Maxed,
		Characters_10Combo,
		Characters_10Combo_Clear,
		Characters_10Combo_Maxed,
		Characters_GoGoStart,
		Characters_GoGoStart_Clear,
		Characters_GoGoStart_Maxed,
		Characters_Become_Cleared,
		Characters_Become_Maxed,
		Characters_SoulOut,
		Characters_ClearOut,
		Characters_Return,
		Characters_Balloon_Breaking,
		Characters_Balloon_Broke,
		Characters_Balloon_Miss,
		Characters_Kusudama_Idle,
		Characters_Kusudama_Breaking,
		Characters_Kusudama_Broke,
		Characters_Kusudama_Miss,
		Characters_Title_Entry,
		Characters_Title_Normal,
		Characters_Menu_Loop,
		Characters_Menu_Select,
		Characters_Menu_Start,
		Characters_Menu_Wait,
		Characters_Result_Clear,
		Characters_Result_Failed,
		Characters_Result_Failed_In,
		Characters_Result_Normal,
		Characters_Tower_Standing,
		Characters_Tower_Climbing,
		Characters_Tower_Running,
		Characters_Tower_Clear,
		Characters_Tower_Fail,
		Characters_Tower_Standing_Tired,
		Characters_Tower_Climbing_Tired,
		Characters_Tower_Running_Tired,
		Characters_Tower_Clear_Tired;
	public CTexture[] Characters_Heya_Preview,
		Characters_Heya_Render,
		Characters_Result_Clear_1P,
		Characters_Result_Failed_1P,
		Characters_Result_Clear_2P,
		Characters_Result_Failed_2P;
	public CCharacter[] Characters;

	#endregion

	#region [12_OnlineLounge]

	public CTexture
		//OnlineLounge_Background,
		OnlineLounge_Box,
		OnlineLounge_Center_Menu_Bar,
		OnlineLounge_Center_Menu_Box_Slot,
		OnlineLounge_Side_Menu,
		OnlineLounge_Context,
		OnlineLounge_Return_Box,
		OnlineLounge_Song_Box;

	#endregion

	#region [13_TowerSelect]

	public CTexture
		TowerSelect_Tower;

	#endregion


	#region [ 解放用 ]
	public List<CTexture> listTexture = new List<CTexture>();
	#endregion

}
