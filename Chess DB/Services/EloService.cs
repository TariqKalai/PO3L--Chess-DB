using System;

public class FideEloCalculator
{
    public void Apply(Game game)
    {
        var a = game.Player1;
        var b = game.Player2;

        double sa = ScoreForPlayer1(game.Result);      // W pour Player1
        double sb = 1.0 - sa;

        int ra = a.Elo;
        int rb = b.Elo;

        // D = Ra - Rb (FIDE)
        int dA = ra - rb;
        int dB = rb - ra;

        // Cap à 400 sauf exception 2650+ (depuis 01/10/2025)
        dA = CapRatingDiff(dA, ra);
        dB = CapRatingDiff(dB, rb);

        double ea = Expected(dA);
        double eb = Expected(dB);

        int kA = KFactor(a.Elo);
        int kB = KFactor(b.Elo);

        int newRa = (int)Math.Round(ra + kA * (sa - ea));
        int newRb = (int)Math.Round(rb + kB * (sb - eb));

        a.Elo = newRa;
        b.Elo = newRb;


    }

    private static double Expected(int d)
        => 1.0 / (1.0 + Math.Pow(10.0, -d / 400.0));

    private static double ScoreForPlayer1(GameResult result) => result switch
    {
        GameResult.Player1Win => 1.0,
        GameResult.Draw => 0.5,
        GameResult.Player2Win => 0.0
    };

    private static int KFactor(int elo)
    {
        if (elo < 2400) return 20;
        return 10;
    }


    // Cap D à 400 si joueur < 2650
    private static int CapRatingDiff(int d, int playerRating)
    {
        if (playerRating >= 2650) return d;             // pas de cap pour 2650+
        if (d > 400) return 400;
        if (d < -400) return -400;
        return d;
    }
}
