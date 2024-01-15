import { Component, OnInit, ViewChild } from '@angular/core';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EventService } from 'src/app/services/data/event.service';
import { PlayerService } from 'src/app/services/data/player.service';
import { TeamService } from 'src/app/services/data/team.service';


import {
  ApexAxisChartSeries,
  ApexChart,
  ChartComponent,
  ApexDataLabels,
  ApexPlotOptions,
  ApexYAxis,
  ApexLegend,
  ApexStroke,
  ApexXAxis,
  ApexFill,
  ApexTooltip
} from "ng-apexcharts";
import { CoachService } from 'src/app/services/data/coach.service';
import { CourseService } from 'src/app/services/data/course.service';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  fill: ApexFill;
  tooltip: ApexTooltip;
  stroke: ApexStroke;
  legend: ApexLegend;
};

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  totalTeams: number = 0;
  totalEvents: number = 0;
  totalPlayers: number = 0;
  totalCourses: number = 0;
  totalCoaches: number = 0;


  constructor(
    private teamService: TeamService,
    private eventService : EventService,
    private playerService : PlayerService,
    private coachservice : CoachService,
    private courseService: CourseService,
    private notifyService : NotifyService
    ) { }

  ngOnInit(): void {
    this.loadTotalTeams();
    this.loadTotalEvents();
    this.loadTotalPlayers();
    this.loadTotalCoach();
    this.loadTotalCourses();
  }

  loadTotalTeams() {
    this.teamService.getTeams().subscribe(
      (teams) => {
        this.totalTeams = teams.length;
      },
      (error) => {
        this.notifyService.message("Failed to load Total Teams!");
      }
    );
  }
  loadTotalCourses() {
    this.courseService.getCourses().subscribe(
      (course) => {
        this.totalTeams = course.length;
      },
      (error) => {
        this.notifyService.message("Failed to load Total Course!");
      }
    );
  }

  loadTotalPlayers() {
    this.playerService.getPlayers().subscribe(
      (players) => {
        this.totalPlayers = players.length;
      },
      (error) => {
        this.notifyService.message("Failed to load Total Players!");
      }
    );
  }
  loadTotalEvents() {
    this.eventService.getEvents().subscribe(
      (events) => {
        this.totalEvents = events.length;
      },
      (error) => {
        this.notifyService.message("Failed to load Total Events!");
      }
    );
  }
  loadTotalCoach() {
    this.coachservice.getCoaches().subscribe(
      (coach) => {
        this.totalCoaches = coach.length;
      },
      (error) => {
        this.notifyService.message("Failed to load Total Coaches!");
      }
    );
  }

  

  chartOptions = {
	  title: {
		  text: "Player Statistics"
	  },
	  animationEnabled: true,
	  axisY: {
		includeZero: true
	  },
	  data: [{
		type: "column", //change type to bar, line, area, pie, etc
		//indexLabel: "{y}", //Shows y value on all Data Points
		indexLabelFontColor: "#5A5757",
		dataPoints: [
			{ x: 10, y: 71 },
			{ x: 20, y: 55 },
			{ x: 30, y: 50 },
			{ x: 40, y: 65 },
			{ x: 50, y: 71 },
			{ x: 60, y: 92, indexLabel: "Highest\u2191" },
			{ x: 70, y: 68 },
			{ x: 80, y: 38, indexLabel: "Lowest\u2193"  },
			{ x: 90, y: 54 },
			{ x: 100, y: 60 }
		]
	  }]
	}
  chartOptions2 = {
    animationEnabled: true,
    theme: "dark2",
    colorSet: "customColorSet",
    title:{
      text: "Course Enrollment"
    },
    data: [{
      type: "doughnut",
      indexLabel: "{name}: {y}",
      innerRadius: "90%",
      yValueFormatString: "#,##0.00'%'",
      dataPoints: [
      { y: 33, name: "Sports Management" },
      { y: 25, name: "Sports Nutrition" },
      { y: 13.5, name: "Sports Psychology" },
      { y: 11, name: "Incineration" },
      { y: 7.7, name: "Sanitary Landfill (with landfill gas collection)" },
      { y: 5.5, name: "Composting" },
      { y: 4, name: "Controlled Landfill" },
      { y: 0.3, name: "Others" }
      ]
    }]
    }
    chartOptions3 = {
      title: {
        text: "Admission in this month"
      },
      theme: "light2",
      animationEnabled: true,
      exportEnabled: true,
      axisY: {
      includeZero: true,
      valueFormatString: "$#,##0k"
      },
      data: [{
      type: "column", //change type to bar, line, area, pie, etc
      yValueFormatString: "$#,##0k",
      color: "#01b8aa",
      dataPoints: [
        { label: "Jan", y: 172 },
        { label: "Feb", y: 189 },
        { label: "Mar", y: 201 },
        { label: "Apr", y: 240 },
        { label: "May", y: 166 },
        { label: "Jun", y: 196 },
        { label: "Jul", y: 218 },
        { label: "Aug", y: 167 },
        { label: "Sep", y: 175 },
        { label: "Oct", y: 152 },
        { label: "Nov", y: 156 },
        { label: "Dec", y: 164 }
      ]
      }]
    }
    longText = `The Shiba Inu is the smallest of the six original and distinct spitz breeds of dog
    from Japan. A small, agile dog that copes very well with mountainous terrain, the Shiba Inu was
    originally bred for hunting.`;
  }           
