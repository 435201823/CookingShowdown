using CookingShowdownCode.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Helper
{
    public class ActorPositionManager
    {
        private Dictionary<String, KeyValuePair<int, int>> map = new();

        public void insert(CharacterEnum character, int x, int y)
        {
            if (!map.ContainsKey(character.GetName()))
            {
                map.Add(character.GetName(), new KeyValuePair<int, int>(x, y));
            }
        }

        public KeyValuePair<int, int> get(CharacterEnum character)
        {
            //如果不存在直接报错
            return map[character.GetName()];
        }

        public int getX(CharacterEnum character)
        {
            return get(character).Key;
        }

        public int getY(CharacterEnum character)
        {
            return get(character).Value;
        }

        public List<ActorMove> moveToPoint(CharacterEnum character,int x,int y)
        {
            var now = map[character.GetName()];
            List<ActorMove> result = new();
            if (now.Key == x && now.Value == y)
            {
                return result;
            }

            if (now.Key != x)
            {
                if (now.Key > x)
                {
                    result.Add(new ActorMove() { x = x - now.Key, y = 0, face = DirectionEnum.Left });
                } 
                else 
                {
                    result.Add(new ActorMove() { x = x - now.Key, y = 0, face = DirectionEnum.Right });
                }
            }
            if (now.Value != y)
            {
                if (now.Value > y)
                {
                    result.Add(new ActorMove() { x = 0, y = y - now.Value, face = DirectionEnum.Up });
                }
                else
                {
                    result.Add(new ActorMove() { x = 0, y = y - now.Value, face = DirectionEnum.Down });
                }
            }

            map[character.GetName()] = new KeyValuePair<int, int>(x, y);
            return result;
        }
    }

    public class ActorMove
    {
        public int x;
        public int y;
        public DirectionEnum face;
    }
}
