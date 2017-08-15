using InControl;

public class PlayerActions : PlayerActionSet {

    public PlayerAction Jump;

    public PlayerActions() {
        Jump = CreatePlayerAction("Jump");
    }

    // http://www.gallantgames.com/pages/incontrol-standardized-controls
    // Action1 = A, X
    // Action2 = B, Circle
    // Action3 = X, Square
    // Action4 = Y, Triangle
    public static PlayerActions CreateWithDefaultBindings() {
        var playerActions = new PlayerActions();
        playerActions.Jump.AddDefaultBinding(Key.Space);
        playerActions.Jump.AddDefaultBinding(InputControlType.Action1);
        playerActions.Jump.AddDefaultBinding(InputControlType.Action2);
        playerActions.Jump.AddDefaultBinding(Mouse.LeftButton);

        return playerActions;
    }
}
