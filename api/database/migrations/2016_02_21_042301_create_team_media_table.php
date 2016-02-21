<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateTeamMediaTable extends Migration {
    public function up() {
        Schema::create('team_media', function (Blueprint $table) {
            $table->increments('id');
            $table->integer('team_id')->unsigned();
            $table->foreign('team_id')->references('id')->on('teams');
            $table->integer('recorded_by')->unsigned();
            $table->foreign('recorded_by')->references('id')->on('users');
            $table->integer('recorded_by_team')->unsigned();
            $table->foreign('recorded_by_team')->references('id')->on('teams');
            $table->boolean('public');
            $table->text('file');
            $table->timestamps();
        });
    }
    public function down() {
        Schema::drop('team_media');
    }
}
