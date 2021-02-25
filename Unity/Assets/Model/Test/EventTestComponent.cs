using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETModel
{
    [ObjectSystem]
    public class EventTestComponentAwakeSystem : AwakeSystem<EventTestComponent>
    {
        public override void Awake(EventTestComponent self)
        {
            self.Awake();
        }
    }
    public class EventTestComponent : Component
    {
        public string m_str = "hello caicai~";
        public int[] m_arrat = { 0, 1, 2, 3 };

        public void Awake()
        {
            Log.Info($"EventTestComponent : {m_str},{m_arrat[2]}");
        }
    }
}
