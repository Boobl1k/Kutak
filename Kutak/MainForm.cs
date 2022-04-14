namespace Kutak;

public partial class MainForm : Form
{
    public override Color BackColor => Color.Black;
    public override string Text => "Kutak";
    private readonly List<int> _inputs = new();

    public MainForm()
    {
        this.AutoScaleMode = AutoScaleMode.Font;
        this.Size = new Size(900, 900);
        var listBox = CreateListBox(100);
        this.Controls.Add(listBox);
        var textBox = CreateInsertTextBox();
        this.Controls.Add(textBox);
        this.Controls.Add(CreateButton((_, _) =>
        {
            if (!int.TryParse(textBox.Text, out var parsed)) return;
            _inputs.Add(parsed);
            listBox.Items.Add(parsed);
        }, "Add", 0, 30));
        this.Controls.Add(CreateButton((_, _) =>
        {
            _inputs.Clear();
            listBox.Items.Clear();
        }, "Clear", 0, 60));
        var outputLabels = CreateOutputLabels();
        var top = -20;
        foreach (var outputLabel in outputLabels)
        {
            outputLabel.Top = top += 20;
            this.Controls.Add(outputLabel);
        }

        this.Controls.Add(CreateButton((_, _) =>
        {
            foreach (var outputLabel in outputLabels)
                outputLabel.UpdateText(_inputs);
        }, "Submit", 0, 100));
    }

    private static TextBox CreateInsertTextBox(int left = 0, int top = 0)
    {
        var textBox = new TextBox();
        textBox.Left = left;
        textBox.Top = top;

        return textBox;
    }

    private static Button CreateButton(EventHandler clickAction, string text, int left = 0, int top = 0)
    {
        var button = new Button();
        button.Left = left;
        button.Top = top;
        button.Text = text;
        button.Click += clickAction;
        button.ForeColor = Color.White;

        return button;
    }

    private static ListBox CreateListBox(int left = 0, int top = 0)
    {
        var listBox = new ListBox();
        listBox.Left = left;
        listBox.Top = top;
        listBox.Size = new Size(100, 800);

        return listBox;
    }

    private static IEnumerable<OutputLabel> CreateOutputLabels() =>
        new List<OutputLabel>
        {
            new OutputLabel(input => { return 123; }, "qqq")
        };
}
