<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateMatchsTable extends Migration {
    public function up() {
        Schema::create('matchs', function (Blueprint $table) {
            $table->increments('id');
            $table->integer('competition')->unsigned();
            $table->foreign('competition')->references('id')->on('competitions');
            $table->integer('match_num')->unsigned();
            $table->integer('r1')->unsigned();
            $table->foreign('r1')->references('id')->on('teams');
            $table->integer('r2')->unsigned();
            $table->foreign('r2')->references('id')->on('teams');
            $table->integer('r3')->unsigned();
            $table->foreign('r3')->references('id')->on('teams');
            $table->integer('b1')->unsigned();
            $table->foreign('b1')->references('id')->on('teams');
            $table->integer('b2')->unsigned();
            $table->foreign('b2')->references('id')->on('teams');
            $table->integer('b3')->unsigned();
            $table->foreign('b3')->references('id')->on('teams');
            $table->timestamps();
        });
    }
    public function down() {
        Schema::drop('matchs');
    }
}
