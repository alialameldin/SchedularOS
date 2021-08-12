using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Algorthim
    {
	public static void FCFS(processINFO[] processesO, ref Queue<processINFO> Scheduler,ref float avgTurnaround, ref float avgWaiting)
        {
            processINFO[] processes = new processINFO[processesO.Length];
            processINFO processtemp;
            avgTurnaround = 0;
            avgWaiting = 0;
            for (int i = 0; i < processesO.Length; i++)
            {
                processes[i] = processINFO.deepCopy(processesO[i]);

            }
            //  processINFO processTemp;
            Scheduler = new Queue<processINFO>();//indexs
            int minIndex = -1;
            int CT = 0;
            int finishedSched;
            while (true)
            {
                finishedSched = 1;
                for (int i = 0; i < processes.Length; i++)
                {
                    if (processes[i].rtime > 0)
                    {
                        finishedSched = 0;
                        if (processes[i].ATime <= CT)
                        {
                            if (minIndex == -1)
                            {
                                minIndex = i;
                            }
                            else if (processes[i].ATime < processes[minIndex].ATime)
                            {
                                minIndex = i;
                            }
                        }
                    }
                }
                if (finishedSched == 0 && minIndex == -1) {
                    CT++;
                     processtemp = new processINFO();
                     processtemp.rtime = 1;
                    processtemp.index =-1;
                    Scheduler.Enqueue(processtemp);
                }
                if (finishedSched == 1)
                {
                    break;
                }
                if (minIndex != -1)
                {
                    processtemp = processINFO.deepCopy(processes[minIndex]);
                    processtemp.startTime = CT;
                    Scheduler.Enqueue(processtemp);
                    CT += processes[minIndex].rtime;
                    processes[minIndex].departureTime = CT;
                    processes[minIndex].rtime = 0;
                    minIndex = -1;
                }

            }

            for (int i = 0; i < processes.Length; i++)
            {
                avgTurnaround += processes[i].departureTime - processes[i].ATime;
                avgWaiting += processes[i].departureTime - processes[i].ATime - processes[i].time;

            }
            avgWaiting /= processes.Length;
            avgTurnaround /= processes.Length;
        }
       
        public static void RR(processINFO[] processesO, ref Queue<processINFO> Scheduler, int Quantum, ref float avgTurnaround, ref float avgWaiting)
        {
            processINFO[] processes = new processINFO[processesO.Length];
            processINFO processtemp;
            int flag = 0;
            avgTurnaround = 0;
            avgWaiting = 0;
            int indexminA;
            for (int i = 0; i < processesO.Length; i++)
            {

                processes[i] = processINFO.deepCopy(processesO[i]);
            }
            for (int i = 0; i < processes.Length; i++)
            {
                indexminA = i;
        
                for (int j = i; j < processes.Length; j++)
                    if (processes[j].ATime <= processes[indexminA].ATime) {
                        if (processes[j].ATime == processes[indexminA].ATime)
                        {
                            if (processes[j].index < processes[indexminA].index)
                                indexminA = j;
                            else
                            {
                                continue;
                            }
                        }
                        else {
                            indexminA = j;
                        }
                           
                    }
                processtemp = processes[i];
                processes[i] = processes[indexminA];
                processes[indexminA] = processtemp;
            }
            
            //  processINFO processTemp;
            Scheduler = new Queue<processINFO>();//indexs
            int CT = 0;
            int finishedSched;
            int[] arr=new int [4];
            arr[0] = 0;
            
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].ATime < arr[0]) {


                }



            }
                while (true)
               {
                finishedSched = 1;
                flag = 0;
                for (int i = 0; i < processes.Length; i++)
                {
                    if (processes[i].rtime > 0)
                    {
                        finishedSched = 0;
                        if (processes[i].ATime <= CT)
                        {
                            flag = 1;
                            processtemp = processINFO.deepCopy(processes[i]);
                            processtemp.startTime = CT;
                            if (processtemp.rtime < Quantum)
                            {
                                Scheduler.Enqueue(processtemp);
                            }
                            else
                            {
                                processtemp.rtime = Quantum;
                                Scheduler.Enqueue(processtemp);
                            }

                            CT += processtemp.rtime;
                            processes[i].departureTime = CT;
                            processes[i].rtime -= processtemp.rtime;

                        }
                    }
                }
                if (flag == 0 && finishedSched != 1)
                {
                    CT++;
                    processtemp = new processINFO();
                    processtemp.rtime = 1;
                    processtemp.index = -1;
                    Scheduler.Enqueue(processtemp);
                }
                if (finishedSched == 1)
                {
                    break;
                }


            }

            for (int i = 0; i < processes.Length; i++)
            {
                avgTurnaround += processes[i].departureTime - processes[i].ATime;
                avgWaiting += processes[i].departureTime - processes[i].ATime - processes[i].time;

            }
            avgWaiting /= processes.Length;
            avgTurnaround /= processes.Length;

        }
        public static void SJFNONPREE(processINFO[] processesO, ref Queue<processINFO> Scheduler, ref float avgTurnaround, ref float avgWaiting)
        {//int nprocess,int[] arrivals,int []time) {
            processINFO[] processes = new processINFO[processesO.Length];
            processINFO processtemp;
            avgTurnaround = 0;
            avgWaiting = 0;
            for (int i = 0; i < processesO.Length; i++)
            {
                processes[i] = processINFO.deepCopy(processesO[i]);

            }
            //  processINFO processTemp;
            Scheduler = new Queue<processINFO>();//indexs
            int minIndex = -1;
            int CT = 0;
            int finishedSched;
            while (true)
            {
                finishedSched = 1;
                for (int i = 0; i < processes.Length; i++)
                {
                    if (processes[i].rtime > 0)
                    {
                        finishedSched = 0;
                        if (processes[i].ATime <= CT)
                        {
                            if (minIndex == -1)
                            {
                                minIndex = i;
                            }
                            else if (processes[i].rtime < processes[minIndex].rtime)
                            {
                                minIndex = i;
                            }
                        }
                    }
                }
                if (finishedSched == 0 && minIndex == -1)
                {
                    CT++;
                    processtemp = new processINFO();
                    processtemp.rtime = 1;
                    processtemp.index = -1;
                    Scheduler.Enqueue(processtemp);
                }
                if (finishedSched == 1)
                {
                    break;
                }
                if (minIndex != -1)
                {
                    processtemp = processINFO.deepCopy(processes[minIndex]);
                    processtemp.startTime = CT;
                    Scheduler.Enqueue(processtemp);
                    CT += processes[minIndex].rtime;
                    processes[minIndex].departureTime = CT;
                    processes[minIndex].rtime = 0;
                    minIndex = -1;
                }

            }

            for (int i = 0; i < processes.Length; i++)
            {
                avgTurnaround += processes[i].departureTime - processes[i].ATime;
                avgWaiting += processes[i].departureTime - processes[i].ATime - processes[i].time;

            }
            avgWaiting /= processes.Length;
            avgTurnaround /= processes.Length;
        }

        public static void SJFPREE(processINFO[] processesO, ref Queue<processINFO> Scheduler, ref float avgTurnaround, ref float avgWaiting)
        {//int nprocess,int[] arrivals,int []time) {
            processINFO[] processes = new processINFO[processesO.Length];
            processINFO processtemp;
            int minCutArrival = -1;
            avgTurnaround = 0;
            avgWaiting = 0;
            for (int i = 0; i < processesO.Length; i++)
            {
                processes[i] = processINFO.deepCopy(processesO[i]);

            }
            //  processINFO processTemp;
            Scheduler = new Queue<processINFO>();//indexs
            int minIndex = -1;
            int CT = 0;
            int finishedSched;
            while (true)
            {
                finishedSched = 1;
                for (int i = 0; i < processes.Length; i++)
                {
                    if (processes[i].rtime > 0)
                    {
                        finishedSched = 0;
                        if (processes[i].ATime <= CT)
                        {
                            if (minIndex == -1)
                            {
                                minIndex = i;
                            }
                            else if (processes[i].rtime < processes[minIndex].rtime)
                            {
                                minIndex = i;
                            }
                        }
                    }
                }
                if (finishedSched == 0 && minIndex == -1)
                {
                    CT++;
                    processtemp = new processINFO();
                    processtemp.rtime = 1;
                    processtemp.index = -1;
                    Scheduler.Enqueue(processtemp);
                }
                if (finishedSched == 1)
                {
                    break;
                }
                if (minIndex != -1)
                {
                    processtemp = processINFO.deepCopy(processes[minIndex]);
                    processtemp.startTime = CT;
                    for (int i = 0; i < processes.Length; i++)
                    {

                        if (processes[i].rtime > 0 && (processes[i].ATime < (processes[minIndex].rtime + CT)) && (processes[minIndex].ATime < processes[i].ATime)&& (processes[i].ATime >CT) && (processes[i].rtime < (processes[minIndex].rtime - (processes[i].ATime - CT))))
                        {
                            if (minCutArrival == -1)
                            {
                                minCutArrival = processes[i].ATime;

                            }
                            else if (minCutArrival > processes[i].ATime)
                            {

                                minCutArrival = processes[i].ATime;
                            }
                        }

                    }

                    if (minCutArrival != -1)
                    {

                        processtemp.rtime = minCutArrival - CT;
                        CT += processtemp.rtime;

                    }
                    else
                    {
                        CT += processes[minIndex].rtime;
                    }


                    Scheduler.Enqueue(processtemp);

                    processes[minIndex].departureTime = CT;
                    processes[minIndex].rtime -= processtemp.rtime;
                    minIndex = -1;
                    minCutArrival = -1;

                }

            }

            for (int i = 0; i < processes.Length; i++)
            {
                avgTurnaround += processes[i].departureTime - processes[i].ATime;
                avgWaiting += processes[i].departureTime - processes[i].ATime - processes[i].time;

            }
            avgWaiting /= processes.Length;
            avgTurnaround /= processes.Length;





        }

        public static void priority_nonPreemp(processINFO[] processesO, ref Queue<processINFO> Scheduler, ref float avgTurnaround, ref float avgWaiting)
        {//int nprocess,int[] arrivals,int []time) {
            processINFO[] processes = new processINFO[processesO.Length];
            processINFO processtemp;
            avgTurnaround = 0;
            avgWaiting = 0;
            for (int i = 0; i < processesO.Length; i++)
            {
                processes[i] = processINFO.deepCopy(processesO[i]);

            }
            //  processINFO processTemp;
            Scheduler = new Queue<processINFO>();//indexs
            int minIndex = -1;
            int CT = 0;
            int finishedSched;
            while (true)
            {
                finishedSched = 1;
                for (int i = 0; i < processes.Length; i++)
                {
                    if (processes[i].rtime > 0)
                    {
                        finishedSched = 0;
                        if (processes[i].ATime <= CT)
                        {
                            if (minIndex == -1)
                            {
                                minIndex = i;
                            }
                            else if (processes[i].priority < processes[minIndex].priority)
                            {
                                minIndex = i;
                            }
                        }
                    }
                }
                if (finishedSched == 0 && minIndex == -1)
                {
                    CT++;
                    processtemp = new processINFO();
                    processtemp.rtime = 1;
                    processtemp.index = -1;
                    Scheduler.Enqueue(processtemp);
                }
                if (finishedSched == 1)
                {
                    break;
                }
                if (minIndex != -1)
                {
                    processtemp = processINFO.deepCopy(processes[minIndex]);
                    processtemp.startTime = CT;
                    Scheduler.Enqueue(processtemp);
                    CT += processes[minIndex].rtime;
                    processes[minIndex].departureTime = CT;
                    processes[minIndex].rtime = 0;
                    minIndex = -1;
                }

            }

            for (int i = 0; i < processes.Length; i++)
            {
                avgTurnaround += processes[i].departureTime - processes[i].ATime;
                avgWaiting += processes[i].departureTime - processes[i].ATime - processes[i].time;

            }
            avgWaiting /= processes.Length;
            avgTurnaround /= processes.Length;
        }
        public static void priority_preemptive(processINFO[] processesO, ref Queue<processINFO> Scheduler, ref float avgTurnaround, ref float avgWaiting)
        {//int nprocess,int[] arrivals,int []time) {
            processINFO[] processes = new processINFO[processesO.Length];
            processINFO processtemp;
            int minCutArrival = -1;
            avgTurnaround = 0;
            avgWaiting = 0;
            for (int i = 0; i < processesO.Length; i++)
            {
                processes[i] = processINFO.deepCopy(processesO[i]);

            }
            //  processINFO processTemp;
            Scheduler = new Queue<processINFO>();//indexs
            int minIndex = -1;
            int CT = 0;
            int finishedSched;
            while (true)
            {
                finishedSched = 1;
                for (int i = 0; i < processes.Length; i++)
                {
                    if (processes[i].rtime > 0)
                    {
                        finishedSched = 0;
                        if (processes[i].ATime <= CT)
                        {
                            if (minIndex == -1)
                            {
                                minIndex = i;
                            }
                            else if (processes[i].priority < processes[minIndex].priority)
                            {
                                minIndex = i;
                            }
                        }
                    }
                }
                if (finishedSched == 0 && minIndex == -1)
                {
                    CT++;
                    processtemp = new processINFO();
                    processtemp.rtime = 1;
                    processtemp.index = -1;
                    Scheduler.Enqueue(processtemp);
                }
                if (finishedSched == 1)
                {
                    break;
                }
                if (minIndex != -1)
                {
                    processtemp = processINFO.deepCopy(processes[minIndex]);
                    processtemp.startTime = CT;
                    for (int i = 0; i < processes.Length; i++)
                    {

                        if (processes[i].rtime > 0 && (processes[i].ATime < (processes[minIndex].rtime + CT)) && (processes[minIndex].ATime < processes[i].ATime) && (processes[i].priority < processes[minIndex].priority))
                        {
                            if (minCutArrival == -1)
                            {
                                minCutArrival = processes[i].ATime;

                            }
                            else if (minCutArrival > processes[i].ATime)
                            {

                                minCutArrival = processes[i].ATime;
                            }
                        }

                    }

                    if (minCutArrival != -1)
                    {

                        processtemp.rtime = minCutArrival - CT;
                        CT += processtemp.rtime;

                    }
                    else
                    {
                        CT += processes[minIndex].rtime;
                    }


                    Scheduler.Enqueue(processtemp);

                    processes[minIndex].departureTime = CT;
                    processes[minIndex].rtime -= processtemp.rtime;
                    minIndex = -1;
                    minCutArrival = -1;

                }

            }

            for (int i = 0; i < processes.Length; i++)
            {
                avgTurnaround += processes[i].departureTime - processes[i].ATime;
                avgWaiting += processes[i].departureTime - processes[i].ATime - processes[i].time;

            }
            avgWaiting /= processes.Length;
            avgTurnaround /= processes.Length;


        }
    }
}
