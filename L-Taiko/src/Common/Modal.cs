﻿namespace OpenTaiko;

internal class Modal {
	public Modal(EModalType mt, int ra, params object?[] re) {
		modalType = mt;
		rarity = ra;
		reference = re;
	}

	public void tRegisterModal(int player) {
		OpenTaiko.ModalManager.RegisterNewModal(player, rarity, modalType, reference);
	}

	#region [Enum definitions]

	public enum EModalType {
		Coin = 0,
		Character = 1,
		Puchichara = 2,
		Title = 3,
		Song = 4,
		Total = 5,
	}

	#endregion

	#region [Public variables]

	// Coin number for coin; database/unlockable asset for puchichara, character and title; no effect on text, confirm
	public object?[] reference;

	public int rarity;
	public EModalType modalType;

	// For modalFormat = Half only
	public int player;

	#endregion

}
