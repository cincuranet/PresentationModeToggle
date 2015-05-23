﻿using System.Runtime.InteropServices;

namespace PresentationModeToggle
{
	static class Interop
	{
		public const int S_OK = 0x00000000;

		[DllImport("shell32.dll")]
		public static extern int SHQueryUserNotificationState(out QUERY_USER_NOTIFICATION_STATE pquns);
		public enum QUERY_USER_NOTIFICATION_STATE
		{
			QUNS_NOT_PRESENT = 1,
			QUNS_BUSY = 2,
			QUNS_RUNNING_D3D_FULL_SCREEN = 3,
			QUNS_PRESENTATION_MODE = 4,
			QUNS_ACCEPTS_NOTIFICATIONS = 5,
			QUNS_QUIET_TIME = 6
		}
	}
}
