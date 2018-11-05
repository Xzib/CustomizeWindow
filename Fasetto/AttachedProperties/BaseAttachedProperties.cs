using System.Windows;

namespace Fasetto
{
    public abstract class BaseAttachedProperties<Parent, Property>
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached
            ("Value", typeof(bool), typeof(BaseAttachedProperties<Parent, Property>), new PropertyMetadata());
            
    }
}
