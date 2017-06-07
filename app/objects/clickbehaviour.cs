using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ruslan.prototype.test.app.helpers
{
    public static class ClickBehavior
    {

        #region properties dependency attached
        /// <summary>
        /// 
        /// </summary>
        public static DependencyProperty ClickBehaviorProperty =
            DependencyProperty.RegisterAttached("ClickBehavior", typeof(ICommand), typeof(ClickBehavior), new FrameworkPropertyMetadata(new PropertyChangedCallback(Clicked)));


        public static DependencyProperty ClickedProperty =
            DependencyProperty.RegisterAttached("Clicked", typeof(object), typeof(ClickBehavior), new FrameworkPropertyMetadata());



        /// <summary>
        /// 
        /// </summary>
        public static ICommand GetClickBehavior(DependencyObject obj)
        {
            return obj.GetValue(ClickBehaviorProperty) as ICommand;
        }
        /// <summary>
        /// 
        /// </summary>
        public static void SetClickBehavior(DependencyObject obj, object value)
        {
            obj.SetValue(ClickBehaviorProperty, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object GetClicked(DependencyObject obj)
        {
        
            return obj.GetValue(ClickedProperty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetClicked(DependencyObject obj, object value)
        {
           obj.SetValue(ClickedProperty, value);
            
        }
        #endregion

        #region event handlers
        /// <summary>
        /// 
        /// </summary>
        static void Clicked(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {

            var element = obj as UIElement;

            if (element != null)
            {
                if (e.NewValue != null && e.OldValue == null)
                {
                    element.MouseLeftButtonUp += new MouseButtonEventHandler(clickbehavior_mouseleftbuttonup);
                }
                else if (e.OldValue != null && e.NewValue == null)
                {
                    element.MouseLeftButtonUp -= clickbehavior_mouseleftbuttonup;
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void clickbehavior_mouseleftbuttonup(object sender, MouseButtonEventArgs e)
        {
            var command = (ICommand)GetClickBehavior(sender as UIElement);
            if (command != null)
            {
                command.Execute(GetClicked(sender as UIElement));

            }
        }

        #endregion
    }
}



