namespace WorkerService
{
    public class Worker : BackgroundService
    {
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            DosyaYaz("Worker Calismaya Basladi " + DateTime.Now);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            DosyaYaz("Worker Calismayi Durdurdu " + DateTime.Now);
            return base.StopAsync(cancellationToken);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DosyaYaz("Worker Calismaya Devam Ediyor " + DateTime.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

        public void DosyaYaz(string mesaj)
        {
            string dosyaYolu = AppDomain.CurrentDomain.BaseDirectory + "/Logs";
            if (!Directory.Exists(dosyaYolu))
            {
                Directory.CreateDirectory(dosyaYolu);
            }
            string textYolu = AppDomain.CurrentDomain.BaseDirectory + "/Logs/Deneme.txt";
            if (!File.Exists(textYolu))
            {
                using(StreamWriter sw = File.CreateText(textYolu))
                {
                    sw.WriteLine(mesaj);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(textYolu))
                {
                    sw.WriteLine(mesaj);
                }
            }
        }
    }
}
