import { Component, OnInit } from '@angular/core';
import { Planet } from '../models/planet';
import { PlanetsService } from '../services/planets.service';

@Component({
  selector: 'app-planets-board',
  templateUrl: './planets-board.component.html',
  styleUrls: ['./planets-board.component.scss']
})
export class PlanetsBoardComponent implements OnInit {
  planets: Planet[];

  constructor(private planetsService: PlanetsService) { }

  ngOnInit(): void {
    this.loadPlanets();
  }

  loadPlanets() {
    this.planetsService.getPlanets().subscribe(planets => {
      this.planets = planets
    });
  }
}
