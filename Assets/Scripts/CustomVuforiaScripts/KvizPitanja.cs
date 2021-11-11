using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KvizPitanja
{
    public string pitanje;
    public List<string> odgovor = new List<string>();
    public int tocan_odgovor;

    public KvizPitanja (string pitanje, List<string> odgovor, int tocan_odgovor)
    {
        odgovor = new List<string>();
        pitanje = this.pitanje;
        odgovor = this.odgovor;
        tocan_odgovor = this.tocan_odgovor;

    }

}
