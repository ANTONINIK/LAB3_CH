namespace LAB3_CH
{
    interface INameAndCopy
    {
        string Name { get; set; }
        public object DeepCopy();
    }
}
