<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreatePitDataTable extends Migration {
    public function up() {
        Schema::create('pit_data', function (Blueprint $table) {
            $table->increments('id');
            $table->integer('team_id')->unsigned();
            $table->foreign('team_id')->references('id')->on('teams');
            $table->integer('recorded_by')->unsigned();
            $table->foreign('recorded_by')->references('id')->on('users');
            $table->integer('recorded_by_team')->unsigned();
            $table->foreign('recorded_by_team')->references('id')->on('teams');
            $table->timestamps();
        });
    }
    public function down() {
        Schema::drop('pit_data');
    }
}
