namespace Gameye.Sdk
{
    public class LogLine
    {
        public string LineKey { get; set; }
        public string Payload { get; set; }

        public override string ToString()
        {
            return $"{LineKey}: ${Payload}";
        }
    }
}
