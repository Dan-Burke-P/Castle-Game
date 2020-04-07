namespace NetworkSystem{
    public enum mode{
        HOST,
        CLIENT
    }

    public enum hostMode{
        WAITING,
        CONNECTED
    }

    public enum clientMode{
        NOHOST,
        CONNECTED,
        ATTEMPTCONN
    }
}