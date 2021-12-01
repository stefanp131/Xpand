import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanetUpdateFormComponent } from './planet-update-form.component';

describe('PlanetUpdateFormComponent', () => {
  let component: PlanetUpdateFormComponent;
  let fixture: ComponentFixture<PlanetUpdateFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlanetUpdateFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanetUpdateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
