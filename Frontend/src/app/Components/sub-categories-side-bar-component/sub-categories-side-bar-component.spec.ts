import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubCategoriesSideBarComponent } from './sub-categories-side-bar-component';

describe('SubCategoriesSideBarComponent', () => {
  let component: SubCategoriesSideBarComponent;
  let fixture: ComponentFixture<SubCategoriesSideBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubCategoriesSideBarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubCategoriesSideBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
