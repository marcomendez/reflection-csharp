using Reflection.Controles;

namespace Reflection.View
{
    [ViewAlias("Login")]
    public class View01 : Iview
    {
        [ControlAlias("User Name")]
        public TextBox UserName => new TextBox();

        [ControlAlias("Save")]
        public Button Save => new Button();

        
    }
}
