<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Http\Requests;
use App\Http\Controllers\Controller;

use App\Models\User;

class FRCScoutController extends Controller {
    
    public function getIndex() {
		return view('pages.home');
	}
	
	public function getRegister($user,$pass,$teamNum) {
		return "true";
	}
	
	public function getLogin($username,$pass) {
		$user = User::where('username', $username)->where('password', $pass)->first();
		
		if($user == null) {
			return "invalid";
		}
		
		return "true";
	}
	
	public function getUserTeam($user) {
		return "3245";
	}
	
	public function getMatchesAtCompetition($competitionID) {
		return [1,2,3,4,5,6,7,8];
	}
	
	public function getTeamsAtCompetition($competitionID) {
		return [3245, 3166, 987, 1717, 4166, 1234, 4321];
	}
	
}