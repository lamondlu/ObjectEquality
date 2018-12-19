﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectEqual
{
    public class ArrayEquality : IEquality
    {
        public Func<object, bool> MatchCondition
        {
            get
            {
                return p => p.GetType().IsArray;
            }
        }

        public bool IsEqual(object source, object target)
        {
            Array s = source as Array;
            Array t = target as Array;

            if (s.Length != t.Length)
            {
                return false;
            }

            for (var i = 0; i < s.Length; i++)
            {
                foreach (var equality in EqualityCollection.Equalities)
                {
                    if (equality.MatchCondition(s.GetValue(i)))
                    {
                        var result = equality.IsEqual(s.GetValue(i), t.GetValue(i));

                        if (!result)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
