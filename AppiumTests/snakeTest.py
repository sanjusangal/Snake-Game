import os
import unittest
import sys
import math
from appium import webdriver
from altunityrunner import AltrunUnityDriver

PATH = lambda p: os.path.abspath(
    os.path.join(os.path.dirname(__file__), p)
)

class SnakeTests(unittest.TestCase):
    altdriver = None
    platform = "android" # set to `ios` or `android` to change platform

    @classmethod
    def setUpClass(cls):
        cls.desired_caps = {}
        if (cls.platform == "android"):
            cls.setup_android()
        else:
            cls.setup_ios()
        cls.driver = webdriver.Remote('http://localhost:4723/wd/hub', cls.desired_caps)
        cls.altdriver = AltrunUnityDriver(cls.driver, cls.platform)

    @classmethod
    def tearDownClass(cls):
        cls.altdriver.stop()
        cls.driver.quit()

    @classmethod
    def setup_android(cls):
        cls.desired_caps['platformName'] = 'Android'
        cls.desired_caps['deviceName'] = 'device'
        cls.desired_caps['app'] = PATH('../sanjuSnakeGame3.apk')
       
    @classmethod
    def setup_ios(cls):
        cls.desired_caps['platformName'] = 'iOS'
        cls.desired_caps['deviceName'] = 'iPhone5'
        cls.desired_caps['automationName'] = 'XCUITest'
        cls.desired_caps['app'] = PATH('../../../sampleGame.ipa')

    def test_start_game(self):
               
        self.altdriver.wait_for_current_scene_to_be('MainMenu')
        self.altdriver.wait_for_element("Canvas")
        self.altdriver.find_element("instructions").mobile_tap()
        self.altdriver.wait_for_current_scene_to_be('Instructions')
        abc = self.altdriver.find_element('Text (1)').get_text()

        print(abc)
        self.altdriver.find_element('Button').mobile_tap()
        self.altdriver.wait_for_current_scene_to_be('MainMenu')
        self.altdriver.find_element('Button').mobile_tap()
        self.altdriver.wait_for_current_scene_to_be('Level')
        textsnake = self.altdriver.find_elements('Text')
        
        
        print(len(textsnake))
        for x in textsnake: 
            #print("hey the texts are: {}".format(x.get_text()))
            print(x.get_text())
        
        self.altdriver.find_element("Level3").mobile_tap()
        self.altdriver.wait_for_current_scene_to_be('snakeGame')
        self.altdriver.find_element("right").mobile_tap()
        print("snake position")
        head = self.altdriver.find_element("head")
        print(head)
        print("food position")
        #food = self.altdriver.find_element("food")
        #print("right border")
        #right_border = self.altdriver.find_element("border_right")
        #print(right_border)
        #dist = math.sqrt((head.x-food.x)**2 + (head.y-food.y)**2) - head.r - food.r
        #print(dist)
        self.altdriver.wait_for_current_scene_to_be('Result')

    
     
    
    def prevent_snake_from_colliding_with_sides(self):
        print("hello")
        
        

if __name__ == '__main__':
    suite = unittest.TestLoader().loadTestsFromTestCase(SnakeTests)
    result = unittest.TextTestRunner(verbosity=2).run(suite)
    sys.exit(not result.wasSuccessful())