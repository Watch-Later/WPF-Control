﻿








using System.Collections.Generic;

namespace H.Controls.Dock.Layout
{
    /// <summary>Defines an interface that is implemented by a layout model that can contain other <see cref="LayoutElement"/>s (<see cref="LayoutGroup{T}"/>, <see cref="LayoutPane"/> etc).</summary>
    public interface ILayoutContainer : ILayoutElement
    {
        #region Properties

        /// <summary>Gets all children elements of this layout container.</summary>
        IEnumerable<ILayoutElement> Children
        {
            get;
        }

        /// <summary>Gets the number of children of this layout container.</summary>
        int ChildrenCount
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>Removes a particular child element from this layout container.</summary>
        void RemoveChild(ILayoutElement element);

        /// <summary>Replaces a particular child element with a new element in this layout container.</summary>
        void ReplaceChild(ILayoutElement oldElement, ILayoutElement newElement);

        #endregion Methods
    }
}