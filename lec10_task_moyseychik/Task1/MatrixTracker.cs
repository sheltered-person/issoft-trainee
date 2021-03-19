using System;
using System.Collections.Generic;

namespace Task1
{
    public class MatrixTracker<T>
    {
        //Store info about last action to undo it, if necessary.
        private Stack<ElementChangedEventArgs<T>> actions;

        private bool undoFlag;

        public ElementChangedEventArgs<T> LastAction { get; private set; }

        public DiagonalMatrix<T> TrackedMatrix { get; }

        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException("Error:" +
                    " tracked matrix can't be null.");
            }

            TrackedMatrix = matrix;
            TrackedMatrix.ElementChanged += ElementChangedHandler;

            actions = new();
            undoFlag = false;
        }

        //Event handler method.
        private void ElementChangedHandler(object sender, 
            ElementChangedEventArgs<T> e)
        {
            if (undoFlag)
            {
                undoFlag = false;
                return;
            }

            LastAction = e;
            actions.Push(e);
        }

        //Undo last change in matrix, if there were some changes.
        public void Undo()
        {
            if (LastAction is null)
            {
                throw new ArgumentNullException("Error: there is no actions " +
                    "with the matrix to undo.");
            }

            undoFlag = true;
            actions.Pop();

            int i = LastAction.Index;
            TrackedMatrix[i, i] = LastAction.OldValue;

            if (actions.TryPeek(out ElementChangedEventArgs<T> e))
            {
                LastAction = e;
            }
            else
            {
                LastAction = null;
            }
        }
    }
}
