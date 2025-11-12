import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubCategoriesAdminPage } from './sub-categories-admin-page';

describe('SubCategoriesAdminPage', () => {
  let component: SubCategoriesAdminPage;
  let fixture: ComponentFixture<SubCategoriesAdminPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SubCategoriesAdminPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubCategoriesAdminPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
