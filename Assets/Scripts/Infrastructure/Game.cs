using Services.Input;

namespace Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        
        public Game()
        {
            InputService = new InputService();
        }
    }
}