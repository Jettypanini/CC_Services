<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\DB;

class MMFController extends Controller
{
    /**
    * Print a simple "Hello there!"
    *
    * @return \Illuminate\Http\Response
    */
    public function printHallo()
    {
        print("Hello there!");
    }

    /**
    * Geeft op basis van de ingegeven gevoelens een embed terug dat een passende song afspeelt.
    *
    * @return \Illuminate\Http\Response
    */
    public function result($mood)
    {
        $song = DB::table('songs')->where('mood', '=', $mood)->first();
        $url = $song->youtube;
        return "<iframe width='1120' height='630' src='{$url}' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";
    }
}
