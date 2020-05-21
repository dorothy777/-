using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            defstart();

        }
        private void defstart()
        {
            salary.Text = 0.ToString();
            //กลุ่มที่1
            pregnant.Text = 0.ToString();
            child1.Text = 0.ToString();
            child2.Text = 0.ToString();
            disabled.Text = 0.ToString();
            //กลุ่มที่2
            socse.Text = 0.ToString();
            lifese.Text = 0.ToString();
            healse.Text = 0.ToString();
            momdadse.Text = 0.ToString();
            partnerse.Text = 0.ToString();
            sparelife.Text = 0.ToString();
            kbk.Text = 0.ToString();
            kach.Text = 0.ToString();
            pension.Text = 0.ToString();
            ltf.Text = 0.ToString();
            rmf.Text = 0.ToString();
            //กลุ่มที่3
            home.Text = 0.ToString();
            home58.Text = 0.ToString();
            home62.Text = 0.ToString();
            //กลุ่มที่4
            donatex2.Text = 0.ToString();
            donate.Text = 0.ToString();
            donateparty.Text = 0.ToString();
            //กลุ่มที่5
            sport.Text = 0.ToString();
            otop.Text = 0.ToString();
            landmark.Text = 0.ToString();
            city.Text = 0.ToString();
            fixcar.Text = 0.ToString();
            fixhome.Text = 0.ToString();

            partnerse.Enabled = false;
        }

        public int sal = 0, sta = 0, pgn = 0, ch1 = 0, ch2 = 0, moda = 0, dis = 0,
                sse = 0, lse = 0, hse = 0, modase = 0, partse = 0, sparse = 0, kbkse = 0, kachse = 0, pense = 0, ltfc = 0, rmfc = 0,
                homc = 0, hom58 = 0, hom62 = 0,
                donx2 = 0, don = 0, donpar = 0,
                sportc = 0, otopc = 0, lanc = 0, cityc = 0, fhom = 0, fcar = 0,
                yinc = 0, cos = 0, disc = 0, netw = 0, taxall = 0, childdis = 0,momdaddis = 0,disdis = 0;

        private void btnnext1_Click(object sender, EventArgs e)
        {
            page1.SelectedTab = tabPage2;
            
            if (status3.Checked)
            {
                partnerse.Enabled = true;
            }
            else partnerse.Enabled = false;
        }

        private void btnpre_Click(object sender, EventArgs e)
        {
            page1.SelectedTab = tabPage1;
        }

        private void btnnext2_Click(object sender, EventArgs e)
        {
            page1.SelectedTab = tabPage3;
        }

        private void btnpre2_Click(object sender, EventArgs e)
        {
            page1.SelectedTab = tabPage2;
        }

        private void btncal_Click(object sender, EventArgs e)
        {
            page1.SelectedTab = tabPage4;
            Calculate();
        }

        private void btnpre3_Click(object sender, EventArgs e)
        {
            page1.SelectedTab = tabPage3;
            
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            page1.SelectedTab = tabPage1;
            defstart();
        }

        private void page1_Selected(object sender, TabControlEventArgs e)
        {

            if (status3.Checked)
            {
                partnerse.Enabled = true;
            }
            else partnerse.Enabled = false;

            if (!status1.Checked && !status2.Checked && !status3.Checked && page1.SelectedTab == tabPage4)
            {
                MessageBox.Show("กรุณาระบุสถานะของท่าน");
                page1.SelectedTab = tabPage1;
            }

            Calculate();
        }

        private void Calculate()
        {

            //รับข้อมูลหน้าที่ 1
            try
            {
                sal = int.Parse(salary.Text);
                pgn = int.Parse(pregnant.Text);
                ch1 = int.Parse(child1.Text);
                ch2 = int.Parse(child2.Text);
                moda = int.Parse(momdad.Value.ToString());
                dis = int.Parse(disabled.Text);
                sse = int.Parse(socse.Text);
                lse = int.Parse(lifese.Text);
                hse = int.Parse(healse.Text);
            }
            catch
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง");
                page1.SelectedTab = tabPage1;
            }

            yinc = sal * 12;
            
            cos = yinc/2;
            

            //ค่าใช้จ่ายไม่เกิน100000
            if (cos > 100000)
            {
                cos = 100000;
            }
            else cos = cos;
            int cos1 = yinc - cos;
            int tenper = (cos1 * 10) / 100;
            int fifhper = (cos1 * 15) / 100;

            //ตรวจสอบสถานะ
            if(status1.Checked)//โสด
            {
                sta = 60000;
            }
            else if(status2.Checked)//คู่สมรสมีรายได้
            {
                sta = 60000;
            }
            else if(status3.Checked)//คู่สมรสขาดรายได้
            {
                sta = 120000;
            }

            //ค่าฝากครรถ์
            if(pgn<60000)
            {
                pgn = pgn;
            }
            else if(pgn>=60000)
            {
                pgn = 60000;
            }

            //ลดหย่อนลูก
            if(ch1 == 0 && ch2 == 1)
            {
                childdis = (ch1 * 30000) + (ch2 * 30000);
            }
            else if(ch1 > 0 && ch2 > 0)
            {
                childdis = (ch1 * 30000) + (ch2 * 60000);
            }
            else if(ch1 == 0 && ch2 > 1 )
            {
                childdis = 30000 + ((ch2 - 1) * 60000);
            }
            else if(ch1 > 0 && ch2 == 0)
            {
                childdis = ch1 * 30000;
            }

            //ลดหย่อนบุพการี
            momdaddis = moda * 30000;

            //ลดหย่อนคนพิการ
            disdis = dis * 60000;

            //รับข้อมูลหน้าที่ 2
            try
            {
                modase = int.Parse(momdadse.Text);
                partse = int.Parse(partnerse.Text);
                sparse = int.Parse(sparelife.Text);
                kbkse = int.Parse(kbk.Text);
                kachse = int.Parse(kach.Text);
                pense = int.Parse(pension.Text);
                ltfc = int.Parse(ltf.Text);
                rmfc = int.Parse(rmf.Text);
                homc = int.Parse(home.Text);
                hom58 = int.Parse(home58.Text);
                hom62 = int.Parse(home62.Text);
            }
            catch
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง");
                page1.SelectedTab = tabPage2;
            }

            //ประกันสังคม
            if (sse < 9000)
            {
                sse = sse;
            }
            else if (sse >= 9000)
            {
                sse = 9000;
            }

            //ประกันชีวิต
            if (lse < 100000)
            {
                lse = lse;
            }
            else if (lse >= 100000)
            {
                lse = 100000;
            }

            //ประกันสุขภาพ
            if (hse < 15000)
            {
                hse = hse;
            }
            else if (hse >= 15000)
            {
                hse = 15000;
            }
            //ประกันชีวิต+ประกันสุขภาพ
            int pragun = lse + hse;
            if (pragun < 100000)
            {
                pragun = pragun;
            }
            else if (pragun >= 100000)
            {
                pragun = 100000;
            }

            //ประกันสุขภาพบิดามารดา
            if (modase < 15000)
            {
                modase = modase;
            }
            else if (modase >= 15000)
            {
                modase = 15000;
            }

            //เงินกองทุนสำรองเลี้ยงชีพ
            int spar1 = 0;

            if (fifhper >= 490000)
            {
                fifhper = 490000;
            }

            if (sparse <= 10000)
            {
                spar1 = sparse;
            }
            
            if (sparse - 10000 > fifhper)
            {
                spar1 = 10000;
            }
            else spar1 = sparse;
            

            //ประกันชีวิตคู่สมรส
            if (partse < 10000)
            {
                partse = partse;
            }
            else if (partse >= 10000)
            {
                partse = 10000;
            }

            fifhper = (cos1 * 15) / 100;

            //ltf
            if (ltfc < 500000 && ltfc < fifhper)
            {
                ltfc = ltfc;
            }
            else if (fifhper >= 500000 && ltfc < fifhper)
            {
                ltfc = 500000;
            }
            else if (ltfc >= fifhper && ltfc <= 500000)
            {
                ltfc = fifhper;
            }
            else if (ltfc >= fifhper && ltfc >= 500000)
            {
                ltfc = fifhper;
            }

            //rmf
            if (rmfc < 500000 && rmfc < fifhper)
            {
                rmfc = rmfc;
            }
            else if (fifhper >= 500000 && rmfc < fifhper)
            {
                rmfc = 500000;
            }
            else if (rmfc >= fifhper && rmfc <= 500000)
            {
                rmfc = fifhper;
            }
            else if (rmfc >= fifhper && rmfc >= 500000)
            {
                rmfc = fifhper;
            }


            //เงินสะสมกองทุน กบข.
            if (kbkse < 500000 && kbkse < fifhper)
            {
                kbkse = kbkse;
            }
            else if (fifhper >= 500000 && kbkse < fifhper)
            {
                kbkse = 500000;
            }
            else if (kbkse >= fifhper && kbkse <= 500000)
            {
                kbkse = fifhper;
            }
            else if (kbkse >= fifhper && kbkse >= 500000)
            {
                kbkse = fifhper;
            }

            //เบี้ยประกันชีวิตแบบบำนาญ
            if (pense < 200000 && pense < fifhper)
            {
                pense = pense;
            }
            else if (fifhper >= 200000 && pense < fifhper)
            {
                pense = 200000;
            }
            else if (pense >= fifhper && pense <= 200000)
            {
                pense = fifhper;
            }
            else if (pense >= fifhper && pense >= 200000)
            {
                pense = fifhper;
            }

            //บำนาญ + กบข. + rmf ไม่เกินห้าแสน
            int kbkrmfpen = kbkse + rmfc + pense;
            if (kbkrmfpen < 500000)
            {
                kbkrmfpen = kbkrmfpen;
            }
            else if (kbkrmfpen >= 500000)
            {
                kbkrmfpen = 500000;
            }

            //เงินสะสม กอช.
            if (kachse < 13200)
            {
                kachse = kachse;
            }
            else if (kachse >= 13200)
            {
                kachse = 13200;
            }

            //ดอกเบี้ยบ้าน
            if (homc<100000)
            {
                homc = homc;
            }
            else if(homc>=100000)
            {
                homc = 100000;
            }

            //บ้านหลังแรก58
            hom58 = (hom58 * 4) / 100;

            //บ้านหลังแรก62
            if(hom62<200000)
            {
                hom62 = hom62;
            }
            else if(hom62>=20000)
            {
                hom62 = 200000;
            }

            //รับข้อมูลหน้าที่ 3
            try
            {
                donx2 = int.Parse(donatex2.Text);
                don = int.Parse(donate.Text);
                donpar = int.Parse(donateparty.Text);
                sportc = int.Parse(sport.Text);
                otopc = int.Parse(otop.Text);
                lanc = int.Parse(landmark.Text);
                cityc = int.Parse(city.Text);
                fhom = int.Parse(fixhome.Text);
                fcar = int.Parse(fixcar.Text);
            }
            catch
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง");
                page1.SelectedTab = tabPage3;
            }


            //บริจาคพรรคการเมือง
            if (donpar < 10000)
            {
                donpar = donpar;
            }
            else if(donpar >= 10000)
            {
                donpar = 10000;
            }

            //อุปกรณ์กีฬาและการศึกษา
            if (sportc < 15000)
            {
                sportc = sportc;
            }
            else if (sportc >= 15000)
            {
                sportc = 15000;
            }
            //สินค้าotop
            if (otopc < 15000)
            {
                otopc = otopc;
            }
            else if (otopc >= 15000)
            {
                otopc = 15000;
            }

            //เที่ยวเมืองหลัก
            if (lanc < 15000)
            {
                lanc = lanc;
            }
            else if (lanc >= 15000)
            {
                lanc = 15000;
            }
            //เที่ยวเมืองรอง
            if (cityc < 20000)
            {
                cityc = cityc;
            }
            else if (cityc >= 20000)
            {
                cityc = 20000;
            }
            //สองอันรวมกัน
            int tourthai = lanc + cityc;
            if (tourthai < 20000)
            {
                tourthai = tourthai;
            }
            else if (tourthai >= 20000)
            {
                tourthai = 20000;
            }

            //ซ่อมบ้าน
            if (fhom < 100000)
            {
                fhom = fhom;
            }
            else if (fhom >= 100000)
            {
                fhom = 100000;
            }
            //ซ่อมรถ
            if (fcar < 30000)
            {
                fcar = fcar;
            }
            else if (fcar >= 30000)
            {
                fcar = 30000;
            }

            //รวมลดหย่อนภาษีก่อนคิดบริจาค
            disc = (sta + pgn + childdis + momdaddis + disdis) + cos + (sse + pragun + modase + spar1 + partse + ltfc + kbkrmfpen + kachse) + 
                   (homc + hom58 + hom62) + (tourthai + sportc + otopc + fhom + fcar) + donpar;
            int tenperdonate = (disc * 10) / 100;

            //บริจาค2เท่า
            int donx2_2 = donx2 * 2;
            if(donx2_2 < tenperdonate)
            {
                donx2_2 = donx2_2;
            }
            else if(donx2_2 >= tenperdonate)
            {
                donx2_2 = tenperdonate;
            }

            //บริจาคทั่วไป
            if(don < tenperdonate)
            {
                don = don;
            }
            else if(don >= tenperdonate)
            {
                don = tenper;
            }

            //รวมลดหย่อนภาษี
            disc = (sta + pgn + childdis + momdaddis + disdis) + (sse + pragun + modase + spar1 + partse + ltfc + kbkrmfpen + kachse) + 
                   (homc + hom58 + hom62) + (tourthai + sportc + otopc + fhom + fcar) + (donpar + don + donx2_2);


            netw = yinc - disc - cos;
            if (netw < 0)
            {
                net.Text = 0.ToString();
            }
            else net.Text = netw.ToString();
            
            yincome.Text = yinc.ToString();
            cost.Text = cos.ToString();
            discount.Text = disc.ToString();

            //คิดภาษีแบบขั้นบันได
            int money = 0, f1 = 0, f2 = 0, f3 = 0, f4 = 0, f5 = 0, f6 = 0, f7 = 0, f8 = 0;
            money = netw;
            if (money > 0)
            {
                //ขั้นที่1
                f1 = money * 0 / 100;
                taxall = money - 150000;
                //ขั้นที่2
                if (taxall > 0 && taxall <= 150000)
                {
                    f2 = (taxall * 5) / 100;
                }
                else if (taxall > 0 && taxall > 150000)
                {
                    f2 = (150000 * 5) / 100;
                    taxall = taxall - 150000;
                    //ขั้นที่3
                    if (taxall > 0 && taxall <= 200000)
                    {
                        f3 = (taxall * 10) / 100;
                    }
                    else if (taxall > 0 && taxall > 200000)
                    {
                        f3 = (200000 * 10) / 100;
                        taxall = taxall - 200000;
                        //ขั้นที่4
                        if (taxall > 0 && taxall <= 250000)
                        {
                            f4 = (taxall * 15) / 100;
                        }
                        else if (taxall > 0 && taxall > 250000)
                        {
                            f4 = (250000 * 15) / 100;
                            taxall = taxall - 250000;
                            //ขั้นที่5
                            if (taxall > 0 && taxall <= 250000)
                            {
                                f5 = (taxall * 20) / 100;
                            }
                            else if (taxall > 0 && taxall > 250000)
                            {
                                f5 = (250000 * 20) / 100;
                                taxall = taxall - 250000;
                                //ขั้นที่6
                                if (taxall > 0 && taxall <= 1000000)
                                {
                                    f6 = (taxall * 25) / 100;
                                }
                                else if (taxall > 0 && taxall > 1000000)
                                {
                                    f6 = (1000000 * 25) / 100;
                                    taxall = taxall - 1000000;
                                    //ขั้นที่7
                                    if (taxall > 0 && taxall <= 3000000)
                                    {
                                        f7 = (taxall * 30) / 100;
                                    }
                                    else if (taxall > 0 && taxall > 3000000)
                                    {
                                        f7 = (3000000 * 30) / 100;
                                        taxall = taxall - 3000000;
                                        //ขั้นที่8
                                        if (taxall > 0)
                                        {
                                            f8 = (taxall * 35) / 100;
                                        }
                                    }
                                }
                            }

                        }
                    }

                }
            }
            else if (money <= 0)
            {
                taxall = 0;
            }

            //ภาษีที่ต้องจ่าย
            taxall = f1 + f2 + f3 + f4 + f5 + f6 + f7 + f8;
            tax.Text = taxall.ToString();

        }
    }
}
