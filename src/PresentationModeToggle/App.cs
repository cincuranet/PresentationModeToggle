using System.Diagnostics;
using System.Windows.Forms;

namespace PresentationModeToggle
{
	class App
	{
		static void Main(string[] args)
		{
			var state = SHQueryUserNotificationState();
			if (state != null)
			{
				var toggleResult = state == Interop.QUERY_USER_NOTIFICATION_STATE.QUNS_PRESENTATION_MODE
					? ExecutePresentationSettings("stop")
					: ExecutePresentationSettings("start");
				if (!toggleResult)
				{
					ShowProblem("Unable to toggle Presentation Mode.");
				}
			}
			else
			{
				ShowProblem("Unable to get Presentation Mode status.");
			}
		}

		static Interop.QUERY_USER_NOTIFICATION_STATE? SHQueryUserNotificationState()
		{
			Interop.QUERY_USER_NOTIFICATION_STATE state;
			return Interop.SHQueryUserNotificationState(out state) == Interop.S_OK
				? state
				: (Interop.QUERY_USER_NOTIFICATION_STATE?)null;
		}

		static bool ExecutePresentationSettings(string action)
		{
			var psi = new ProcessStartInfo();
			psi.FileName = "PresentationSettings.exe";
			psi.Arguments = string.Format("/{0}", action);
			try
			{
				using (var process = Process.Start(psi))
				{ }
			}
			catch
			{
				return false;
			}
			return true;
		}

		static void ShowProblem(string text)
		{
			MessageBox.Show(text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
}
