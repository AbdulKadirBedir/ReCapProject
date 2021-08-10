using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public object Message => _loggingEvent.MessageObject;
    }
}
/* 
 Serileştirme, nesneyi depolamak veya belleği, 
 bir veritabanı ya da bir dosyaya aktarmak için bir nesneyi bayt akışına dönüştürme işlemidir.
 Temel amacı, bir nesnenin durumunu gerektiğinde yeniden oluşturmak için kaydetmeyecektir.
 Ters işlem serisini kaldırma olarak adlandırılır.
 */