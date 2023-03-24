﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowValidation
{
    public class AssertionStep : Step, IStep
    {
        private readonly Func<AssertionContext, bool> _step;

        /// <summary>
        /// Defines a step that will be run
        /// </summary>
        public AssertionStep(Func<AssertionContext, bool> step)
        {
            _step = step;
        }

        /// <summary>
        /// Executes the step
        /// </summary>
        /// <param name="context">The current execution context</param>
        /// <returns>The resulting collection of the executions</returns>
        public override void Run(WorkflowContext context)
        {
            if (!_step(new AssertionContext(context)))
            {
                throw new WorkflowException("Step is not true");
            }
        }
    }
}
