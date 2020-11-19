using System;
using System.Threading;

namespace ONX.Cmn
{
    /// <summary>
    /// Clase utilizada para realizar la limpieza de Objetos en Memoria
    /// </summary>
    public class MemoryCleaner
    {
        /// <summary>
        /// Constante Intervalo de tiempo para la revisión de la carga en memoria
        /// </summary>
        private const int PERIOD_IN_MS = 500;
        /// <summary>
        /// Contador de eventos de bloqueo
        /// </summary>
        private static int Counter_;
        /// <summary>
        /// Hilo de programación
        /// </summary>
        private Thread thread_;
        /// <summary>
        /// Manejador de interbloqueo de eventos.
        /// </summary>
        private AutoResetEvent event_ = new AutoResetEvent(false);
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public MemoryCleaner()
        {
        }
        /// <summary>
        /// Método utilizado para iniciar el proceso de recolección de objetos en Memoria
        /// </summary>
        public void Start()
        {
            Stop();
            thread_ = new Thread(new ThreadStart(run));
            thread_.Name = string.Format("MemoryCleaner#{0}", Interlocked.Increment(ref Counter_));
            thread_.IsBackground = true; // this makes thread to be stopped when Main thread is over
            event_.Reset();
            thread_.Start();
        }
        /// <summary>
        /// Método utilizado para detener el proceso de recolección de objetos en Memoria
        /// </summary>
        public void Stop()
        {
            if (thread_ != null)
            {
                event_.Set();
                thread_.Join();
                thread_ = null;
            }
        }
        /// <summary>
        /// Método utilzado como un subproceso de un hilo de ejecución dedicado a liberar la memoria.
        /// </summary>
        private void run()
        {
            while (!event_.WaitOne(PERIOD_IN_MS, false))
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
