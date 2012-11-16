using System;
using System.Diagnostics;

namespace AP_SysLogWriter {

	/**
	 * Simple class to write events to the Windows Application event log.
	 * @author Adam Presley
	 */
	public class EventLogWriter {
		public string SourceName { get; set; }

		public EventLogWriter(string sourceName) {
			this.SourceName = sourceName;

			if (!EventLog.SourceExists(this.SourceName))
				EventLog.CreateEventSource(this.SourceName, "Application");
		}

		public void write(string message, EventLogEntryType messageType) {
			EventLog newLog = new EventLog();
			newLog.Source = this.SourceName;
			newLog.WriteEntry(message, messageType);
		}
	}

}
