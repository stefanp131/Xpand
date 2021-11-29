import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlanetsBoardComponent } from './planets-board.component';

describe('PlanetsBoardComponent', () => {
  let component: PlanetsBoardComponent;
  let fixture: ComponentFixture<PlanetsBoardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlanetsBoardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlanetsBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
