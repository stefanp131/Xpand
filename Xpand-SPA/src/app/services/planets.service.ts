import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Planet } from '../models/planet';

@Injectable({
  providedIn: 'root'
})
export class PlanetsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getPlanets() {
    return this.http.get<Planet[]>(this.baseUrl + 'planets');
  }

  getPlanet(id: number) {
    return this.http.get<Planet>(this.baseUrl + 'planets/' + id);
  }

  updatePlanet(id: number, planet: Planet) {
    return this.http.put<Planet>(this.baseUrl + 'planets/' + id, planet);
  }
}
