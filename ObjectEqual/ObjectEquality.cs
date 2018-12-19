﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ObjectEqual
{
    public class ObjectEquality
    {
        public bool IsEqual(object source, object target)
        {
            if (source.GetType() != target.GetType())
            {
                return false;
            }

            var equality = EqualityCollection.Equalities.First(p => p.MatchCondition(source));

            return equality.IsEqual(source, target);
        }
    }
}
