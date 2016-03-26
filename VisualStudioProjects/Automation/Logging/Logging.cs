using System;

namespace Automation
{
	public static class Logging
	{
		private static string LoggingPrefix = "";
		private static Action<string> LogHandler = null;

		/// <summary>
		/// Sets the logging prefix.
		/// </summary>
		/// <param name="prefix">The new prefix.</param>
		public static void SetLoggingPrefix(string prefix)
		{
			LoggingPrefix = prefix;
		}

		/// <summary>
		/// Overwrites the log handler.
		/// </summary>
		/// <param name="logHandler">The new log handler.</param>
		public static void OverwriteLogHandler(Action<string> logHandler)
		{
			LogHandler = logHandler;
		}

		/// <summary>
		/// Logs the specified message with formating
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="values">The values.</param>
		public static void Log(string message, params object[] values)
		{
			Log(string.Format(message, values));
		}

		/// <summary>
		/// Logs the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		public static void Log(string message)
		{
			message = string.Format("{0}{1}", LoggingPrefix, message);
			if (LogHandler != null)
				LogHandler.Invoke(message);
			else
				SimpleLog(message);
		}

		/// <summary>
		/// Logs the message if no LogHandler is specified using simple Console log
		/// </summary>
		/// <param name="message">The message.</param>
		private static void SimpleLog(string message)
		{
			Console.WriteLine(message);
		}
	}
}