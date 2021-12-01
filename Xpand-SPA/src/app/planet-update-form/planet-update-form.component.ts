import { parseI18nMeta } from '@angular/compiler/src/render3/view/i18n/meta';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { Planet } from '../models/planet';
import { User } from '../models/user';
import { AccountService } from '../services/account.service';
import { PlanetsService } from '../services/planets.service';

export interface MatSelectValue {
  name: string;
  id: number;
}

@Component({
  selector: 'app-planet-update-form',
  templateUrl: './planet-update-form.component.html',
  styleUrls: ['./planet-update-form.component.scss']
})
export class PlanetUpdateFormComponent implements OnInit {
  planet: Planet;
  planetForm: FormGroup;  
  currentUser: User;
  matSelectValues: MatSelectValue[];


  constructor(private planetsService: PlanetsService, private route: ActivatedRoute, private formBuilder: FormBuilder, 
    private snackBar: MatSnackBar, private router: Router, private accountService: AccountService, private cdRef: ChangeDetectorRef) { 
      this.matSelectValues = [
        { name: 'Ok', id: 0},
        { name: '!Ok', id: 1},
        { name: 'To Do', id: 2},
        { name: 'En Route', id: 3}
      ]
    }

  ngOnInit(): void {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.currentUser = user);

    this.initForm();
    this.loadPlanet();
  }

  loadPlanet() {
    const id =  this.route.snapshot.params.id;
    this.planetsService.getPlanet(id).subscribe(planet => {
      this.planet = planet;
      this.planetForm.get('description').setValue(planet.description);
      this.planetForm.get('status').setValue(planet.status);
      this.cdRef.detectChanges();
    })
  }

  initForm() {
    this.planetForm = this.formBuilder.group({
      description: [''],
      status: ['']
    })
  }

  update() {
    const id =  this.route.snapshot.params.id;
    const formValue = this.planetForm.value;
    this.planet.description = formValue.description;
    this.planet.status = formValue.status;
    this.planet.lastEditedBy = this.currentUser.userName;
    this.planet.robotsCrew =  this.currentUser.robotsCrew;

    this.planetsService.updatePlanet(id, this.planet).subscribe(() => {
      this.router.navigate(['./planets-board']);
      this.snackBar.open('Successfully updated!', 'Dismiss', { duration: 5000 })
    });
  }

  compareStatus(o1: MatSelectValue, o2: MatSelectValue) {
    if(o1.name == o2.name && o1.id == o2.id )
    return true;
    else return false
  }
}
