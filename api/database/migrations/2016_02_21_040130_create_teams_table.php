<?php

use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateTeamsTable extends Migration {
    public function up() {
        Schema::create('teams', function (Blueprint $table) {
            $table->increments('id');
            $table->string('team_num');
            $table->text('name');
            $table->timestamps();
        });
    }
    public function down() {
        Schema::drop('teams');
    }
}
