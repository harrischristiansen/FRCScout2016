<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Http\Requests;
use App\Http\Controllers\Controller;

use App\Models\Team;

class FRCScoutController extends Controller {
    
    public function getIndex() {
		return view('pages.home');
	}
	
	public function getCreateUser($user,$pass,$teamNum) {
		return "true";
	}
	
	public function getLogin($user,$pass) {
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