

/*
 
 * Example tag (Replace TAGNAME)



[Transaction(TransactionMode.Manual)]
public class TAGNAME : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {

        //Loop until tagging is esc is pressed
        while (true)
        {

            //List of size tags
            var TagFam = tagtools.SaveInformation(this.GetType().Name);

            //Select Element
            var element = tagtools.Pickelement(commandData, TagFam.Category);
            if (element.Item2 == 0) break;

            //Tag Element
            if (tagtools.tag
                (commandData,
                TagFam.Category,
                TagFam.Family,
                TagFam.Path,
                TagFam.TagFamily,
                TagFam.Leader,
                element.Item1)
                == 0) break;

        }
        return Result.Succeeded;
    }
} 
*/



using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Intech;
using System.Windows;
using System.Windows.Forms;
namespace Intech


{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]

    //Settings
    public class TagSettings : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //Revit pre setup stuff
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Transaction trans = new Transaction(doc);
            UIDocument uidoc = commandData.Application.ActiveUIDocument;

            //start settings form
            DialogResult form = System.Windows.Forms.DialogResult.None;
            using (TagSetting selectionForm = new TagSetting())
            {
                form = selectionForm.ShowDialog();
            }

            return Result.Succeeded;
        }
    }



    //Tags
    [Transaction(TransactionMode.Manual)]
    public class Size : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Elevation : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class Offset : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Number : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Length : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Hanger : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Tag1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = Intech.tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Tag2 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = Intech.tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Tag3 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = Intech.tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Tag4 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = Intech.tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Tag5 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = Intech.tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Tag6 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = Intech.tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Tag7 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = Intech.tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class Tag8 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class Tag9 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }
    [Transaction(TransactionMode.Manual)]
    public class Tag10 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Loop until tagging is esc is pressed
            while (true)
            {

                //List of size tags
                var TagFam = tagtools.SaveInformation(this.GetType().Name);

                //Select Element
                var element = tagtools.Pickelement(commandData, TagFam.Category);
                if (element.Item2 == 0) break;

                //Tag Element
                if (tagtools.tag
                    (commandData,
                    TagFam.Category,
                    TagFam.Family,
                    TagFam.Path,
                    TagFam.TagFamily,
                    TagFam.Leader,
                    element.Item1)
                    == 0) break;

            }

            return Result.Succeeded;
        }
    }
}
