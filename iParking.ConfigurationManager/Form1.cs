using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace iParking.ConfigurationManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class MyBenchmark
        {
            [Benchmark]
            [InnerIterationCount(1000)]
            public void MyMethod()
            {
                // Ph??ng th?c b?n mu?n benchmark
                // Ví d?: Thêm m?t s? l?n c?a m?t chu?i
                string result = "";
                for (int i = 0; i < 1000; i++)
                {
                    result += i.ToString();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var summary = BenchmarkRunner.Run<MyBenchmark>();
            });
        }
    }
}