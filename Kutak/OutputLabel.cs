namespace Kutak;

public sealed class OutputLabel : Label
{
    private readonly Func<List<int>, double> _calculateAction;
    private readonly string _name;

    public OutputLabel(Func<List<int>, double> calculateAction, string name)
    {
        _calculateAction = calculateAction;
        _name = name;
        this.Text = name;
        this.BackColor = Color.White;
        this.Left = 250;
    }

    public sealed override string Text
    {
        get => base.Text;
        set => base.Text = value;
    }

    public void UpdateText(List<int> input) => 
        this.Text = $"{_name} : {_calculateAction(input)}";
}
