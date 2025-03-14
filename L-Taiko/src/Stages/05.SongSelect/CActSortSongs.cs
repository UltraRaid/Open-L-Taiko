﻿namespace OpenTaiko;

internal class CActSortSongs : CActSelectPopupMenu {

	// Constructor

	public CActSortSongs() {
	}

	public override void Activate() {
		List<CItemBase> lci = new List<CItemBase>();
		lci.Add(new CItemList(CLangManager.LangInstance.GetString("SONGSELECT_SORT_PATH"), CItemBase.EPanelType.Normal, 0, "", "", new string[] { "Z,Y,X,...", "A,B,C,..." }));
		lci.Add(new CItemList(CLangManager.LangInstance.GetString("SONGSELECT_SORT_TITLE"), CItemBase.EPanelType.Normal, 0, "", "", new string[] { "Z,Y,X,...", "A,B,C,..." }));
		lci.Add(new CItemList(CLangManager.LangInstance.GetString("SONGSELECT_SORT_SUBTITLE"), CItemBase.EPanelType.Normal, 0, "", "", new string[] { "Z,Y,X,...", "A,B,C,..." }));
		lci.Add(new CItemList(CLangManager.LangInstance.GetString("SONGSELECT_SORT_LEVEL"), CItemBase.EPanelType.Normal, 0, "", "", new string[] { "13,12,11,...", "1,2,3,..." }));
#if TEST_SORTBGM
			lci.Add( new CItemList( "BPM",			CItemBase.EPanelType.Normal, 0, "", "", new string[] { "300,200,...",	"70,80,90,..." } ) );
#endif
		lci.Add(new CItemList(CLangManager.LangInstance.GetString("MENU_RETURN"), CItemBase.EPanelType.Normal, 0, "", "", new string[] { "", "" }));
		base.Initialize(lci, false, CLangManager.LangInstance.GetString("SONGSELECT_SORT"));
		base.Activate();
	}

	// メソッド
	public void tActivatePopupMenu(EInstrumentPad einst, ref CActSelect曲リスト ca) {
		this.act曲リスト = ca;
		base.tActivatePopupMenu(einst);
	}

	public override void tEnter押下Main(int nSortOrder) {
		nSortOrder *= 2;    // 0,1  => -1, 1
		nSortOrder -= 1;
		switch ((EOrder)n現在の選択行) {
			case EOrder.Path:
				this.act曲リスト.t曲リストのソート(
					CSongs管理.tSongListSortByPath, nSortOrder
				);
				this.act曲リスト.t選択曲が変更された(true);
				break;
			case EOrder.Title:
				this.act曲リスト.t曲リストのソート(
					CSongs管理.tSongListSortByTitle, nSortOrder
				);
				this.act曲リスト.t選択曲が変更された(true);
				break;
			case EOrder.Subtitle:
				this.act曲リスト.t曲リストのソート(
					CSongs管理.tSongListSortBySubtitle, nSortOrder
				);
				this.act曲リスト.t選択曲が変更された(true);
				break;
			case EOrder.Level:
				this.act曲リスト.t曲リストのソート(
					CSongs管理.tSongListSortByLevel, nSortOrder
				);
				this.act曲リスト.t選択曲が変更された(true);
				break;
#if TEST_SORTBGM
						case (int) ESortItem.BPM:
						this.act曲リスト.t曲リストのソート(
							CSongs管理.t曲リストのソート9_BPM順, eInst, nSortOrder,
							this.act曲リスト.n現在のアンカ難易度レベル
						);
					this.act曲リスト.t選択曲が変更された(true);
						break;
#endif
			case EOrder.Return:
				this.tDeativatePopupMenu();
				break;
			default:
				break;
		}
	}

	// CActivity 実装

	public override void DeActivate() {
		if (!base.IsDeActivated) {
			base.DeActivate();
		}
	}

	#region [ private ]
	//-----------------

	private CActSelect曲リスト act曲リスト;

	private enum EOrder : int {
		Path = 0,
		Title = 1,
		Subtitle = 2,
		Level = 3,
		Return = 4
	}

	//-----------------
	#endregion
}
