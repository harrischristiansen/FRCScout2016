<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateMatchDataTable extends Migration {
    public function up() {
        Schema::create('match_data', function (Blueprint $table) {
            $table->increments('id');
            $table->integer('team_id')->unsigned();
            $table->foreign('team_id')->references('id')->on('teams');
            $table->integer('recorded_by')->unsigned();
            $table->foreign('recorded_by')->references('id')->on('users');
            $table->integer('recorded_by_team')->unsigned();
            $table->foreign('recorded_by_team')->references('id')->on('teams');
            $table->integer('match_id')->unsigned();
            $table->foreign('match_id')->references('id')->on('matches');
            $table->timestamps();
        });
    }
    public function down() {
        Schema::drop('match_data');
    }
}
